//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BooksShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Books
    {
        public Books()
        {
            this.OrderBook = new HashSet<OrderBook>();
            this.ReaderComments = new HashSet<ReaderComments>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public System.DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
        public decimal UnitPrice { get; set; }
        public string ContentDescription { get; set; }
        public string TOC { get; set; }
        public int CategoryId { get; set; }
        public int Clicks { get; set; }
    
        public virtual Categories Categories { get; set; }
        public virtual Categories Categories1 { get; set; }
        public virtual Categories Categories2 { get; set; }
        public virtual Categories Categories3 { get; set; }
        public virtual Publishers Publishers { get; set; }
        public virtual ICollection<OrderBook> OrderBook { get; set; }
        public virtual ICollection<ReaderComments> ReaderComments { get; set; }
    }
}
