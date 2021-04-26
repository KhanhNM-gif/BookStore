namespace Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models.ViewModel;

    public partial class OnlineShopContext : DbContext
    {
        public OnlineShopContext()
            : base("name=OnlineShopContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<BookTag> BookTags { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PublishingCompany> PublishingCompanies { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BookView> BookViews { get; set; }
        public virtual DbSet<Keyword> GetKeywords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Ad>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Book>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Book>()
                .Property(e => e.Tags)
                .IsUnicode(false);

            modelBuilder.Entity<BookTag>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.TypeID)
                .IsUnicode(false);

            modelBuilder.Entity<MenuType>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipMobile)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PublishingCompany>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<PublishingCompany>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<BookView>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<BookView>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<BookView>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BookView>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BookView>()
                .Property(e => e.Tags)
                .IsUnicode(false);

            modelBuilder.Entity<BookShort>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<BookShort>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<BookShort>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BookShort>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(19, 4);
        }
    }
}
