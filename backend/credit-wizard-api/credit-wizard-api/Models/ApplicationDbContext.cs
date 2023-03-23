﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace credit_wizard_api.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // TODO Add Classes
        public DbSet<Modul> Moduls { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<SemesterPlanner> SemesterPlanners { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Modul>()
                .HasIndex(u => u.Abbreviation)
            .IsUnique();

            builder.Entity<SemesterPlanner>()
                .HasKey(x => new { x.UserId, x.SemesterId });

            builder.Entity<DegreeModul>()
                .HasKey(x => new { x.ModulId, x.DegreeId });

            builder.Entity<User>().HasData(new List<User>
            {
                new()
                {
                    Id = Guid.Parse("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                    Email = "hans.mustermann@email.ch",
                    MatriculationNumber = "11-111-11",
                    PasswordHash = "551a54b35aa91f347d223e0e19d114e0bacbafbf2e879dc839057b90efefbe6f" //Welcome$23
                }
            });

            builder.Entity<Semester>().HasData(new List<Semester>()
            {
                new()
                {
                    Id = Guid.Parse("7879d617-ca43-482e-9377-fbd55e2976fa"),
                    Number = 1
                },
                new()
                {
                    Id = Guid.Parse("26082676-ac5f-4a34-bfea-cebba3889b1f"),
                    Number = 2
                },
                new()
                {
                    Id = Guid.Parse("189a7100-1e13-458c-bda4-c9fcbab360fd"),
                    Number = 3
                },
                new()
                {
                    Id = Guid.Parse("8c9c8f1e-8484-4d4c-b61e-c7cc905cc1b1"),
                    Number = 4
                },
                new()
                {
                    Id = Guid.Parse("addcfd52-30f3-48f4-8e2d-ab7ee149eacf"),
                    Number = 5
                },
                new()
                {
                    Id = Guid.Parse("185fc9bd-3b34-4ebc-811e-87023698eed0"),
                    Number = 6
                },
                new()
                {
                    Id = Guid.Parse("f3f42629-056e-49de-abc9-59948ccf9ee6"),
                    Number = 7
                },
                new()
                {
                    Id = Guid.Parse("78273aa4-0b1f-4dcd-9b6b-d9bf464dae39"),
                    Number = 8
                }
            });

            builder.Entity<Degree>().HasData(new List<Degree>
            {
                new()
                {
                    Id = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    Name = "Bachelor of Science in Business Information Technology",
                    Description = "This degree program is designed to equip students with a blend of business and IT skills, focusing on areas such as business strategy, data analysis, and software development. Graduates are prepared for careers in a variety of industries where technology plays a critical role in business operations.",
                }
            });

            builder.Entity<Modul>().HasData(new List<Modul>
            {
                new()
                {
                    Id = Guid.Parse("f8ccaae7-014d-4ba7-8c24-4249be07b1c1"),
                    Name = "Accounting",
                    Description = "An overview of financial accounting principles and practices.",
                    Abbreviation = "WACC"
                },
                new()
                {
                    Id = Guid.Parse("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f"),
                    Name = "Business Information Systems",
                    Description = "An introduction to the role of information systems in modern organizations.",
                    Abbreviation  ="WBIS"
                },
                new()
                {
                    Id = Guid.Parse("6c381c6f-9d9a-4b69-aa13-33a8a94a1277"),
                    Name = "Grundlagen BWL",
                    Description = "Eine Einführung in die Betriebswirtschaftslehre.",
                    Abbreviation = "WBWL"
                },
                new()
                {
                    Id = Guid.Parse("e0a6f205-64b7-42ab-bce3-39f0b3841c71"),
                    Name = "Datenmanagement & Datenanalyse",
                    Description = "Eine Einführung in die Verwaltung und Analyse von Daten.",
                    Abbreviation = "WDDA"
                },
                new()
                {
                    Id = Guid.Parse("480cc771-16a7-4176-8c2b-9a73c1df7b34"),
                    Name = "Digital Enterprise",
                    Description = "An exploration of the impact of digital technologies on business operations.",
                    Abbreviation = "WDEN"
                },
                new()
                {
                    Id = Guid.Parse("8f0680b7-68c2-4157-aafc-78c72f63a16f"),
                    Name = "English",
                    Description = "Developing proficiency in the English language for business communication.",
                    Abbreviation = "WENG"
                },
                new()
                {
                    Id = Guid.Parse("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"),
                    Name = "Grundlagen WI",
                    Description = "Introduction to the basics of business informatics.",
                    Abbreviation = "WGWI"
                },
                new()
                {
                    Id = Guid.Parse("686e6a0c-7f51-4c9d-b968-f6ba201df221"),
                    Name = "Kommunikation",
                    Description = "Effective communication in a business environment.",
                    Abbreviation ="WKOM"
                },
                new()
                {
                    Id = Guid.Parse("6cb76b54-5f27-4b6d-936d-8f6d7b77ce68"),
                    Name = "Projektmanagement",
                    Description = "Managing projects from start to finish with an emphasis on planning, execution, and control.",
                    Abbreviation = "WPR1"
                },
                new()
                {
                    Id = Guid.Parse("2aa07a0c-7f51-4c9d-b968-f6ba201df221"),
                    Name = "Business Case Studies",
                    Description = "Analysis and evaluation of real-world business cases to gain insights and develop problem-solving skills.",
                    Abbreviation = "BBCS"
                },
                new()
                {
                    Id = Guid.Parse("eb2dbecc-d0d6-44ef-82eb-34284633ef19"),
                    Name = "Innovation & Entrepreneurship",
                    Description = "Innovation is the process of developing new ideas, products, services, or processes that create value for customers. ntrepreneurship is the process of creating or starting a new business venture in order to make a profit.",
                    Abbreviation = "WIEN"
                },
                new()
                {
                    Id = Guid.Parse("7eaf3d1c-f214-4115-892b-8e1f1675897b"),
                    Name = "Domain Driven Design",
                    Description = "Domain Driven Design is an approach to software development that focuses on understanding and modeling the business domain of an application.",
                    Abbreviation = "WDDD"
                },
                new()
                {
                    Id = Guid.Parse("19b1c514-fb71-414a-8e0a-1f708e1e136e"),
                    Name = "Web Engineering",
                    Description = "Web engineering is the process of designing, developing, testing, and maintaining web applications.",
                    Abbreviation = "WWEN"
                }
            });

            builder.Entity<DegreeModul>().HasData(new List<DegreeModul>()
            {
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    ModulId = Guid.Parse("f8ccaae7-014d-4ba7-8c24-4249be07b1c1"),
                    IsRequried = true,
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = true,
                    ModulId = Guid.Parse("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = true,
                    ModulId = Guid.Parse("6c381c6f-9d9a-4b69-aa13-33a8a94a1277")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = true,
                    ModulId = Guid.Parse("e0a6f205-64b7-42ab-bce3-39f0b3841c71")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = true,
                    ModulId = Guid.Parse("480cc771-16a7-4176-8c2b-9a73c1df7b34")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = true,
                    ModulId = Guid.Parse("8f0680b7-68c2-4157-aafc-78c72f63a16f")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = true,
                    ModulId = Guid.Parse("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = true,
                    ModulId = Guid.Parse("686e6a0c-7f51-4c9d-b968-f6ba201df221")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = true,
                    ModulId = Guid.Parse("6cb76b54-5f27-4b6d-936d-8f6d7b77ce68")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = true,
                    ModulId = Guid.Parse("2aa07a0c-7f51-4c9d-b968-f6ba201df221")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = false,
                    ModulId = Guid.Parse("eb2dbecc-d0d6-44ef-82eb-34284633ef19")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = false,
                    ModulId = Guid.Parse("7eaf3d1c-f214-4115-892b-8e1f1675897b")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequried = false,
                    ModulId = Guid.Parse("19b1c514-fb71-414a-8e0a-1f708e1e136e")
                },
            });


        }
    }
}
