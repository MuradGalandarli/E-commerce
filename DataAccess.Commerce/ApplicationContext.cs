using EntityCommerce;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Commerce
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Goods> Goodses { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Patments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Lieks { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CouponGoods> CouponGoods { get; set; }
        public DbSet<OtherCampaign> OtherCampaigns { get; set; }
        public DbSet<FavoriteGoods> FavoriteGoods { get; set; }  
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerLike> AnswersLikes { get; set; }
        public DbSet<QuestionLike> QuestionLikes { get; set; }

    }

}
