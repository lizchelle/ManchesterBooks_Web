﻿
using ManchesterBooksWeb2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ManchesterBooksWeb2.DataAccess;

public class ApplicationDbContext : IdentityDbContext

{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<CoverType> CoverTypes { get; set; }

    public DbSet<Product> Products { get; set; }


}
