using System.ComponentModel;

namespace Business.Models.Report
{
    public class BooksReportModel
    {
        [DisplayName("Book Name")]
        public string BookName { get; set; }

        public string ProductDescription { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        [DisplayName("Unit Price")]
        public string UnitPriceText { get; set; }

        [DisplayName("Stock Amount")]
        public int StockAmount { get; set; }

        public double UnitPrice { get; set; }
    }
}
