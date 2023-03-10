// <auto-generated />
using CarpoolingWebAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarpoolingWebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230208062839_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarPoolingWebAPI.Models.Booking", b =>
                {
                    b.Property<string>("BookingID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DriverID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeatsBooked")
                        .HasColumnType("int");

                    b.Property<string>("OfferID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CarPoolingWebAPI.Models.History", b =>
                {
                    b.Property<string>("OfferID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookingList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SeatsPerStop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stops")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("OfferID");

                    b.ToTable("History");
                });

            modelBuilder.Entity("CarPoolingWebAPI.Models.Ride", b =>
                {
                    b.Property<string>("OfferID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookingList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SeatsPerStop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stops")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("OfferID");

                    b.ToTable("Rides");
                });

            modelBuilder.Entity("CarPoolingWebAPI.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BookingsMade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OffersMade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CarpoolingWebAPI.Models.UserLogin", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("UserLogin");
                });
#pragma warning restore 612, 618
        }
    }
}
