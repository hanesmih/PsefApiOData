using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using PsefApiOData.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// Simponi API helpers.
    /// </summary>
    public class KemenkeuApiHelper
    {
        /// <summary>
        /// Simponi API helpers.
        /// </summary>
        /// <param name="context">Context Data.</param>
        /// <param name="options">Simponi API configuration options.</param>
        /// <param name="ossApi">Oss API service.</param>
        /// <param name="optionsOss">OSS API configuration options.</param>
        public KemenkeuApiHelper(
            PsefMySqlContext context,
            IOptions<KemenkeuApiOptions> options,
            IOssApiService ossApi,
            IOptions<OssApiOptions> optionsOss
            )
        {
            _context = context;
            _kemenkeuApiOptions = options;
            _helperOss = new OssInfoHelper(ossApi, optionsOss);
        }

        /// <summary>
        /// Get Billing Pnbp.
        /// </summary>
        /// <param name="id">Permohonan Id.</param>
        /// <returns>PermohonanBilling.</returns>
        public async Task<PermohonanBilling> getBillingPnbp(uint id)
        {
            PermohonanBilling billing = await _context.PermohonanBilling.SingleOrDefaultAsync(c => c.PermohonanId == id);

            return billing;
        }

        /// <summary>
        /// Request Billing Pnbp.
        /// </summary>
        /// <param name="pemohon">Object Pemohon.</param>
        /// <param name="permohonanId">permohonanId.</param>
        /// <returns>PermohonanBilling.</returns>
        public async Task<PermohonanBilling> RequestBillingPnbp(Pemohon pemohon, uint permohonanId)
        {
            DateTime dateNow = DateTime.Now;

            OssFullInfo fullInfo = await _helperOss.RetrieveInfo(pemohon.Nib);

            string npwp = fullInfo.NpwpPerseroan ?? _kemenkeuApiOptions.Value.Npwp;

            string nik = "9999999999999999";

            Counter counter = await _context.Counter.SingleOrDefaultAsync(c => c.Name == "Billing");

            counter.LastValueNumber += 1;

            var values = new Dictionary<string, string>
              {
                  { "simponi_req", "{\"method\": \"billingcode_v4\",\"data\": {\"header\": [\"" + counter.LastValueNumber + "\", \"" + _kemenkeuApiOptions.Value.UserId + "\", \"" + _kemenkeuApiOptions.Value.Password + "\", \"" + dateNow.AddDays(_kemenkeuApiOptions.Value.ExpiredDay).ToString("dd-MM-yyyy HH:mm:ss") + "\", \"" + _kemenkeuApiOptions.Value.KodeKL + "\", \"" + _kemenkeuApiOptions.Value.KodeEselon1 + "\", \"" + _kemenkeuApiOptions.Value.KodeSatker + "\", \"" + _kemenkeuApiOptions.Value.JenisPnbp + "\", \"" + _kemenkeuApiOptions.Value.KodeMataUang + "\", " + _kemenkeuApiOptions.Value.TotalNominalBilling + ",\"" + pemohon.CompanyName + "\", \"" + _kemenkeuApiOptions.Value.KodeAkun + "\", \"" + npwp + "\", \"" + nik + "\"], \"detail\": [ [\"" + pemohon.CompanyName + "\", \"" + _kemenkeuApiOptions.Value.KodeTarifSimponi + "\", \"" + _kemenkeuApiOptions.Value.KodePpSimponi + "\", \"" + _kemenkeuApiOptions.Value.KodeAkun + "\", " + _kemenkeuApiOptions.Value.NominalTarifPnbp + ", " + _kemenkeuApiOptions.Value.Volume + ", \"" + _kemenkeuApiOptions.Value.Satuan + "\", " + (_kemenkeuApiOptions.Value.NominalTarifPnbp * _kemenkeuApiOptions.Value.Volume) + ", \"" + _kemenkeuApiOptions.Value.KodeLokasiSatker + "\", \"" + _kemenkeuApiOptions.Value.KodeKabkotaSatker + "\"] ] } }" }
              };

            string url = _kemenkeuApiOptions.Value.IsStaging ? _kemenkeuApiOptions.Value.UrlDev : _kemenkeuApiOptions.Value.UrlProd;

            var content = new FormUrlEncodedContent(values);

            var response = await _client.PostAsync(url, content);

            JObject responseObj = JObject.Parse(await response.Content.ReadAsStringAsync() ?? string.Empty);
            Console.WriteLine(responseObj["response"]);

            PermohonanBilling create = new PermohonanBilling();
            if (responseObj["response"]["code"].ToString() == "00")
            {
                create.PermohonanId = permohonanId;
                create.TransaksiIdKL = counter.LastValueNumber.ToString();
                create.TransaksiIdSimponi = responseObj["response"]["data"][0].ToString();
                create.KodeBillingSimponi = responseObj["response"]["data"][1].ToString();
                create.TglJamBilling = responseObj["response"]["data"][2].ToString();
                create.TglJamExpiredBilling = responseObj["response"]["data"][3].ToString();

                _context.PermohonanBilling.Add(create);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    throw;
                }
            }

            return create;
        }

        /// <summary>
        /// Request Billing Pnbp.
        /// </summary>
        /// <param name="billing">Object PermohonanBilling.</param>
        /// <param name="permohonanId">permohonanId.</param>
        /// <returns>PermohonanBilling.</returns>
        public async Task<PermohonanBilling> RequestStatusBillingPnbp(PermohonanBilling billing, uint permohonanId)
        {
            var values = new Dictionary<string, string>
              {
                  { "simponi_req", "{\"method\": \"inquirybilling_v2\",\"data\":[\"" + billing.TransaksiIdKL + "\",\"" + _kemenkeuApiOptions.Value.UserId + "\",\"" + _kemenkeuApiOptions.Value.Password + "\",\"" + billing.KodeBillingSimponi + "\",\"" + _kemenkeuApiOptions.Value.KodeKL + "\",\"" + _kemenkeuApiOptions.Value.KodeEselon1 + "\",\"" + _kemenkeuApiOptions.Value.KodeSatker + "\"]}" }
              };

            string url = _kemenkeuApiOptions.Value.IsStaging ? _kemenkeuApiOptions.Value.UrlDev : _kemenkeuApiOptions.Value.UrlProd;

            var content = new FormUrlEncodedContent(values);

            var response = await _client.PostAsync(url, content);

            JObject responseObj = JObject.Parse(await response.Content.ReadAsStringAsync() ?? string.Empty);
            PermohonanBilling update = billing;

            if (responseObj["response"]["code"].ToString() == "00")
            {
                update.NTB = responseObj["response"]["data"][1].ToString();
                update.NTPN = responseObj["response"]["data"][2].ToString();
                update.TglJamPembayaran = responseObj["response"]["data"][3].ToString();
                update.BankPersepsi = NamaBank(responseObj["response"]["data"][4].ToString() ?? "");
                update.ChannelPembayaranID = ChannelPembayaran(responseObj["response"]["data"][5].ToString() ?? "");
                update.TglBuku = responseObj["response"]["data"][6].ToString();
                update.StatusBayar = 1;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    throw;
                }
            }

            Console.WriteLine(responseObj);

            StatusApiKemenkeu status = new StatusApiKemenkeu();
            status.code = responseObj["response"]["code"].ToString();

            return update;
        }

        private StatusApiKemenkeu StatusApiKemenkeu(StatusApiKemenkeu status)
        {
            switch (status.code)
            {
                case "00":
                    status.description = "Sukses";
                    break;
                case "30":
                    status.description = "jumlah parameter tidak valid";
                    break;
                case "99":
                    status.description = "format request tidak valid";
                    break;
                case "ID":
                    status.description = "paramater tidak valid";
                    break;
                case "IS":
                    status.description = "kode satker tidak valid";
                    break;
                case "IU":
                    status.description = "user tidak valid";
                    break;
                case "NF":
                    status.description = "Kode Billing belum dibayar/kode billing tidak ditemukan";
                    break;
                case "GE":
                    status.description = "general error";
                    break;
                default:
                    break;
            }

            return new StatusApiKemenkeu { code = status.code, description = status.description };
        }

        private string ChannelPembayaran(string id)
        {
            string name = "";
            switch (id)
            {
                case "6010":
                    name = "Force Flagging";
                    break;
                case "7010":
                    name = "ATM";
                    break;
                case "7011":
                    name = "POS";
                    break;
                case "7012":
                    name = "Teller";
                    break;
                case "7013":
                    name = "Phone Banking";
                    break;
                case "7014":
                    name = "Internet Banking";
                    break;
                case "7015":
                    name = "Mobile Banking";
                    break;
                case "7016":
                    name = "Overbooking";
                    break;
                case "7017":
                    name = "Electronic Data Capture (EDC)";
                    break;
                case "7018":
                    name = "EDC Sub Agent";
                    break;
                case "7019":
                    name = "Mobile Application Sub Agent";
                    break;
                case "7020":
                    name = "Internet Banking Pajak Belanja Pemda";
                    break;
                case "8011":
                    name = "Dompet Elektronik";
                    break;
                case "8012":
                    name = "Transfer Bank";
                    break;
                case "8013":
                    name = "Virtual Account";
                    break;
                case "8014":
                    name = "Direct Debit";
                    break;
                case "8015":
                    name = "Credit Card";
                    break;
                default:
                    break;
            }

            return name;
        }

        private string NamaBank(string id)
        {
            MasterBank masterBank = _context.MasterBank.SingleOrDefault(c => c.BankPersepsiId == id);

            if(masterBank == null)
            {
                return "";
            }

            return masterBank.BankPersepsi;
        }

        private readonly IOptions<KemenkeuApiOptions> _kemenkeuApiOptions;
        private readonly PsefMySqlContext _context;
        private readonly OssInfoHelper _helperOss;
        private static readonly HttpClient _client = new HttpClient();
    }
}

