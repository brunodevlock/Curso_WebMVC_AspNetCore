using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {

        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            //validação pra saber se o banco de dados já foi populado
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; //O Banco de dados já foi populado
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Financeiro");
            Department d3 = new Department(3, "Vendas");
            Department d4 = new Department(4, "Marketing");


            Seller s1 = new Seller(1, "Bruno", "bruno@gmail.com", new DateTime(1987, 8, 14), 10.000, d1);
            Seller s2 = new Seller(2, "Guilherme", "Guilherme@gmail.com", new DateTime(1987, 7, 14), 1.000, d2);
            Seller s3 = new Seller(3, "Gabriel", "Gabriel@gmail.com", new DateTime(1987, 9, 14), 1.000, d3);
            Seller s4 = new Seller(4, "Felipe", "Felipe@gmail.com", new DateTime(1987, 6, 14), 7.000, d2);

            SalesRecords sr1 = new SalesRecords(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s4);
            SalesRecords sr2 = new SalesRecords(2, new DateTime(2018, 09, 28), 1000.0, SaleStatus.Billed, s2);
            SalesRecords sr3 = new SalesRecords(3, new DateTime(2018, 08, 25), 1000.0, SaleStatus.Billed, s1);
            SalesRecords sr4 = new SalesRecords(4, new DateTime(2018, 12, 25), 711000.0, SaleStatus.Billed, s3);
            SalesRecords sr5 = new SalesRecords(5, new DateTime(2018, 10, 25), 11.0, SaleStatus.Billed, s2);


            _context.Department.AddRange(d1,d2,d3,d4);
            _context.Seller.AddRange(s1,s2,s3,s4);
            _context.SalesRecord.AddRange(sr1,sr2,sr3,sr4,sr5);

            _context.SaveChanges();

        }
    } 
}
