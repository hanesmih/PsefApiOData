using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PsefApiOData.Models;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// Counter helpers.
    /// </summary>
    public class CounterHelper
    {
        /// <summary>
        /// Counter helpers.
        /// </summary>
        /// <param name="context">Database context.</param>
        public CounterHelper(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets next form number
        /// </summary>
        /// <param name="type">Type of form number to get.</param>
        /// <param name="numberFunc">Additional number formatting function (ex: convert to Roman number).</param>
        /// <param name="yearFunc">Additional year formatting function.</param>
        /// <param name="monthFunc">Additional month formatting function.</param>
        /// <param name="dayFunc">Additional day formatting function.</param>
        /// <returns>Next form number.</returns>
        public async Task<string> GetFormNumber(
            CounterType type,
            Func<int, string> numberFunc = null,
            Func<DateTime, string> yearFunc = null,
            Func<DateTime, string> monthFunc = null,
            Func<DateTime, string> dayFunc = null)
        {
            bool done = false;
            Counter counter = null;
            int currentNumber = 0;
            string currentCounterDate;

            while (!done)
            {
                counter = await _context.Counter.FindAsync((ushort)type);
                currentCounterDate = string.IsNullOrEmpty(counter.DateFormat) ?
                    counter.LastValueDate :
                    string.Format(counter.DateFormat, DateTime.Now);
                currentNumber = currentCounterDate == counter.LastValueDate ?
                    counter.LastValueNumber + 1 :
                    1;

                counter.LastValueDate = currentCounterDate;
                counter.LastValueNumber = currentNumber;

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    ex.Entries.Single().Reload();
                    continue;
                }

                done = true;
            }

            if (numberFunc == null)
            {
                numberFunc = EmptyNumberFunction;
            }

            if (yearFunc == null)
            {
                yearFunc = EmptyDateTimeFunction;
            }

            if (monthFunc == null)
            {
                monthFunc = EmptyDateTimeFunction;
            }

            if (dayFunc == null)
            {
                dayFunc = EmptyDateTimeFunction;
            }

            return string.Format(
                counter.DisplayFormat,
                currentNumber,
                DateTime.Now,
                numberFunc(currentNumber),
                yearFunc(DateTime.Now),
                monthFunc(DateTime.Now),
                dayFunc(DateTime.Now));
        }

        private static string EmptyNumberFunction(int number)
        {
            return string.Empty;
        }

        private static string EmptyDateTimeFunction(DateTime dateTime)
        {
            return string.Empty;
        }

        private readonly PsefMySqlContext _context;
    }
}