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
    
    public partial class Categories
    {
        public Categories()
        {
            this.Books = new HashSet<Books>();
            this.Books1 = new HashSet<Books>();
            this.Books2 = new HashSet<Books>();
            this.Books3 = new HashSet<Books>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> PId { get; set; }
        public Nullable<int> SortNum { get; set; }
    
        public virtual ICollection<Books> Books { get; set; }
        public virtual ICollection<Books> Books1 { get; set; }
        public virtual ICollection<Books> Books2 { get; set; }
        public virtual ICollection<Books> Books3 { get; set; }
    }
}