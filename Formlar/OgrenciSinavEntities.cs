using Proje_Ogrenci_Akademisyen.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Windows.Forms;

namespace Proje_Ogrenci_Akademisyen.Entity
{
    
    public partial class OgrenciSinavEntities : DbContext
    {
        
        public OgrenciSinavEntities()
            : base("name=OgrenciSinavEntities")
        {
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        internal object Notlar4()
        {
            throw new NotImplementedException();
        }

        
        public virtual DbSet<TblAkademisyen> TblAkademisyen { get; set; }
        public virtual DbSet<TblBolum> TblBolum { get; set; }
        public virtual DbSet<TblDersler> TblDersler { get; set; }
        public virtual DbSet<TblNotlar> TblNotlar { get; set; }
        public virtual DbSet<TblOgrenci> TblOgrenci { get; set; }
        
    }
}
