﻿// <auto-generated />
using System;
using DataAccess.Commerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Commerce.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CouponGoodsGoods", b =>
                {
                    b.Property<int>("CouponGoodsId")
                        .HasColumnType("integer");

                    b.Property<int>("GoodsId")
                        .HasColumnType("integer");

                    b.HasKey("CouponGoodsId", "GoodsId");

                    b.HasIndex("GoodsId");

                    b.ToTable("CouponGoodsGoods");
                });

            modelBuilder.Entity("EntityCommerce.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnswerId"));

                    b.Property<DateTime>("AnswerDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AnswerText")
                        .HasColumnType("text");

                    b.Property<int>("DisLike")
                        .HasColumnType("integer");

                    b.Property<int>("Like")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("EntityCommerce.AnswerLike", b =>
                {
                    b.Property<int>("AnswerLikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnswerLikeId"));

                    b.Property<int>("AnswerId")
                        .HasColumnType("integer");

                    b.Property<int?>("LikeStatus")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("AnswerLikeId");

                    b.HasIndex("AnswerId");

                    b.ToTable("AnswersLikes");
                });

            modelBuilder.Entity("EntityCommerce.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("PasswordResetTokenExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("EntityCommerce.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("DiscountRate")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GoodsId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("GoodsId");

                    b.HasIndex("SellerId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("EntityCommerce.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("boolean");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityCommerce.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentText")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DisLikeCount")
                        .HasColumnType("integer");

                    b.Property<int?>("GoodsId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("LikeCount")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GoodsId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EntityCommerce.CouponGoods", b =>
                {
                    b.Property<int>("CouponGoodsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CouponGoodsId"));

                    b.Property<string>("CouponName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("CouponGoodsId");

                    b.ToTable("CouponGoods");
                });

            modelBuilder.Entity("EntityCommerce.FavoriteGoods", b =>
                {
                    b.Property<int>("FavoriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FavoriteId"));

                    b.Property<int>("GoodesId")
                        .HasColumnType("integer");

                    b.Property<int?>("GoodsId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("FavoriteId");

                    b.HasIndex("GoodsId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteGoods");
                });

            modelBuilder.Entity("EntityCommerce.Goods", b =>
                {
                    b.Property<int>("GoodsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GoodsId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("GoodsName")
                        .HasColumnType("text");

                    b.Property<float?>("Long")
                        .HasColumnType("real");

                    b.Property<int?>("Price")
                        .HasColumnType("integer");

                    b.Property<int?>("SellerId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<int?>("Stock")
                        .HasColumnType("integer");

                    b.Property<float?>("Weight")
                        .HasColumnType("real");

                    b.Property<float?>("Width")
                        .HasColumnType("real");

                    b.HasKey("GoodsId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SellerId");

                    b.ToTable("Goodses");
                });

            modelBuilder.Entity("EntityCommerce.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ImageId"));

                    b.Property<int?>("GoodsId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("OriginalPath")
                        .HasColumnType("text");

                    b.Property<string>("SavedPath")
                        .HasColumnType("text");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ImageId");

                    b.HasIndex("GoodsId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("EntityCommerce.Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LikeId"));

                    b.Property<int?>("CommentId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusLike")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LikeId");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("Lieks");
                });

            modelBuilder.Entity("EntityCommerce.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("CouponDiscountedPrice")
                        .HasColumnType("numeric");

                    b.Property<int?>("CouponId")
                        .HasColumnType("integer");

                    b.Property<string>("CouponName")
                        .HasColumnType("text");

                    b.Property<int>("GoodsId")
                        .HasColumnType("integer");

                    b.Property<byte>("NumberOfGoods")
                        .HasColumnType("smallint");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("OtherCampaignId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.HasIndex("GoodsId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EntityCommerce.OtherCampaign", b =>
                {
                    b.Property<int>("OtherCampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OtherCampaignId"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GiftNumber")
                        .HasColumnType("integer");

                    b.Property<int>("GoodsId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("NumberOfReceipts")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("OtherCampaignId");

                    b.HasIndex("GoodsId");

                    b.ToTable("OtherCampaigns");
                });

            modelBuilder.Entity("EntityCommerce.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Patments");
                });

            modelBuilder.Entity("EntityCommerce.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionId"));

                    b.Property<int>("DisLike")
                        .HasColumnType("integer");

                    b.Property<int>("Like")
                        .HasColumnType("integer");

                    b.Property<DateTime>("QuestionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("QuestionText")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("EntityCommerce.QuestionLike", b =>
                {
                    b.Property<int>("QuestionLikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionLikeId"));

                    b.Property<int?>("LikeStatus")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionLikeId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionLikes");
                });

            modelBuilder.Entity("EntityCommerce.Seller", b =>
                {
                    b.Property<int>("SellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SellerId"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Rol")
                        .HasColumnType("text");

                    b.Property<string>("SellerGmail")
                        .HasColumnType("text");

                    b.Property<string>("SellerName")
                        .HasColumnType("text");

                    b.Property<string>("SellerSureName")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("SellerId");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("EntityCommerce.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserSureName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CouponGoodsGoods", b =>
                {
                    b.HasOne("EntityCommerce.CouponGoods", null)
                        .WithMany()
                        .HasForeignKey("CouponGoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityCommerce.Goods", null)
                        .WithMany()
                        .HasForeignKey("GoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityCommerce.Answer", b =>
                {
                    b.HasOne("EntityCommerce.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityCommerce.User", "User")
                        .WithMany("Answer")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityCommerce.AnswerLike", b =>
                {
                    b.HasOne("EntityCommerce.Answer", "Answer")
                        .WithMany("AnswerLike")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("EntityCommerce.Campaign", b =>
                {
                    b.HasOne("EntityCommerce.Goods", "Goods")
                        .WithMany("Campaigns")
                        .HasForeignKey("GoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityCommerce.Seller", "Seller")
                        .WithMany("Campaigns")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goods");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("EntityCommerce.Comment", b =>
                {
                    b.HasOne("EntityCommerce.Goods", "Goods")
                        .WithMany("Comments")
                        .HasForeignKey("GoodsId");

                    b.HasOne("EntityCommerce.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goods");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityCommerce.FavoriteGoods", b =>
                {
                    b.HasOne("EntityCommerce.Goods", "Goods")
                        .WithMany("FavoriteGoods")
                        .HasForeignKey("GoodsId");

                    b.HasOne("EntityCommerce.User", "User")
                        .WithMany("FavoriteGoods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goods");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityCommerce.Goods", b =>
                {
                    b.HasOne("EntityCommerce.Category", "Category")
                        .WithMany("Goods")
                        .HasForeignKey("CategoryId");

                    b.HasOne("EntityCommerce.Seller", "Seller")
                        .WithMany("Goods")
                        .HasForeignKey("SellerId");

                    b.Navigation("Category");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("EntityCommerce.Image", b =>
                {
                    b.HasOne("EntityCommerce.Goods", "Goods")
                        .WithMany("Image")
                        .HasForeignKey("GoodsId");

                    b.Navigation("Goods");
                });

            modelBuilder.Entity("EntityCommerce.Like", b =>
                {
                    b.HasOne("EntityCommerce.Comment", "Comment")
                        .WithMany("Like")
                        .HasForeignKey("CommentId");

                    b.HasOne("EntityCommerce.User", "User")
                        .WithMany("Like")
                        .HasForeignKey("UserId");

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityCommerce.Order", b =>
                {
                    b.HasOne("EntityCommerce.Goods", "Goods")
                        .WithMany("Order")
                        .HasForeignKey("GoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityCommerce.User", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goods");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityCommerce.OtherCampaign", b =>
                {
                    b.HasOne("EntityCommerce.Goods", "Goods")
                        .WithMany("OtherCampaign")
                        .HasForeignKey("GoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goods");
                });

            modelBuilder.Entity("EntityCommerce.Question", b =>
                {
                    b.HasOne("EntityCommerce.User", "User")
                        .WithMany("Question")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityCommerce.QuestionLike", b =>
                {
                    b.HasOne("EntityCommerce.Question", "Question")
                        .WithMany("QuestionsLikes")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("EntityCommerce.Seller", b =>
                {
                    b.HasOne("EntityCommerce.ApplicationUser", null)
                        .WithOne("Seller")
                        .HasForeignKey("EntityCommerce.Seller", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityCommerce.User", b =>
                {
                    b.HasOne("EntityCommerce.ApplicationUser", null)
                        .WithOne("usre")
                        .HasForeignKey("EntityCommerce.User", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EntityCommerce.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EntityCommerce.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityCommerce.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EntityCommerce.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityCommerce.Answer", b =>
                {
                    b.Navigation("AnswerLike");
                });

            modelBuilder.Entity("EntityCommerce.ApplicationUser", b =>
                {
                    b.Navigation("Seller")
                        .IsRequired();

                    b.Navigation("usre")
                        .IsRequired();
                });

            modelBuilder.Entity("EntityCommerce.Category", b =>
                {
                    b.Navigation("Goods");
                });

            modelBuilder.Entity("EntityCommerce.Comment", b =>
                {
                    b.Navigation("Like");
                });

            modelBuilder.Entity("EntityCommerce.Goods", b =>
                {
                    b.Navigation("Campaigns");

                    b.Navigation("Comments");

                    b.Navigation("FavoriteGoods");

                    b.Navigation("Image");

                    b.Navigation("Order");

                    b.Navigation("OtherCampaign");
                });

            modelBuilder.Entity("EntityCommerce.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("QuestionsLikes");
                });

            modelBuilder.Entity("EntityCommerce.Seller", b =>
                {
                    b.Navigation("Campaigns");

                    b.Navigation("Goods");
                });

            modelBuilder.Entity("EntityCommerce.User", b =>
                {
                    b.Navigation("Answer");

                    b.Navigation("Comments");

                    b.Navigation("FavoriteGoods");

                    b.Navigation("Like");

                    b.Navigation("Order");

                    b.Navigation("Question");
                });
#pragma warning restore 612, 618
        }
    }
}
