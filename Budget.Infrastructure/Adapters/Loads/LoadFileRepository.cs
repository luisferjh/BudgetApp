using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Budget.Infrastructure.Adapters.Loads
{
    public class LoadFileRepository : ILoadFilesRepository
    {
        protected readonly BudgetDbContext _dbContext;
        public LoadFileRepository(BudgetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBanksFromFileAsync(IEnumerable<Bank> banks)
        {            
            await _dbContext.Banks.AddRangeAsync(banks);           
        }

        public async Task SaveBankFromFile(Stream stream)
        {
            try
            {
                List<Bank> banks = new List<Bank>();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    var columnCount = worksheet.Dimension.Columns;

                    // Loop through each row in the worksheet.
                    for (int row = 4; row <= rowCount; row++)
                    {
                        string Name = (string)worksheet.Cells[row, 1].Value;
                        string Code = (string)worksheet.Cells[row, 2].Value;
                        bool IsNeoBank = (string)worksheet.Cells[row, 3].Value == "NO" ? false : true;
                        string stateText = worksheet.Cells[row, 4].Value?.ToString();
                        int idState = 0;
                        int.TryParse(stateText, out idState);

                        Bank bank = new Bank()
                        {
                            Name = Name,
                            Code = Code,
                            IsNeoBank = IsNeoBank,
                            IdState = idState
                        };

                        banks.Add(bank);    
                    };

                    if (banks.Count > 0)
                    {
                        AddBanksFromFileAsync(banks);
                    }
                                            
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}
