using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;
using MyProject.MultiTenancy;
using MyProject.AutoService;

namespace MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<ServiceRecordStatus> ServiceRecordStatuses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }


        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<StockQuantityHistory> StockQuantityHistories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }
        public DbSet<ServiceRecordDetail> ServiceRecordDetails { get; set; }
        public DbSet<ServiceRecordCustomerComplaint> ServiceRecordCustomerComplaints { get; set; }
        public DbSet<ServiceRecordNote> ServiceRecordNotes { get; set; }
        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options)
        {
        }
    }
}
