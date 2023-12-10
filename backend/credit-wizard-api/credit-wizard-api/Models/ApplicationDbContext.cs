using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Models
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Modul> Moduls { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<DegreeModul> DegreeModuls { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<SemesterPlanner> SemesterPlanners { get; set; }
        public virtual DbSet<SemesterPlannerModul> SemesterPlannerModuls { get; set; }
        public virtual DbSet<SemesterTimeSlot> SemesterTimeSlots { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Modul>()
                .HasIndex(u => u.Abbreviation)
            .IsUnique();

            builder.Entity<SemesterPlanner>()
                .HasIndex(x => new { x.UserId, x.SemesterId })
                .IsUnique();

            builder.Entity<SemesterPlannerModul>()
                .HasKey(x => new { x.SemesterPlannerId, x.ModulId });

            builder.Entity<DegreeModul>()
                .HasKey(x => new { x.ModulId, x.DegreeId });

            #region SeedData

            builder.Entity<SemesterTimeSlot>().HasData(new List<SemesterTimeSlot> {
                new()
                {
                    Id = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835"),
                    Timeslot = "Herbstsemester"
                },
                new()
                {
                    Id = Guid.Parse("49de8d00-7b44-4180-ac26-3e919bbeb658"),
                    Timeslot = "Frühlingssemester",
                }
            });

            builder.Entity<Role>().HasData(new List<Role>
            {
                new()
                {
                    Id = Guid.Parse("4c01b50b-3ece-4cdd-9e2e-a3594c14e928"),
                    Name = "User"
                },
                new()
                {
                    Id = Guid.Parse("dcbcfcf5-69e7-430b-ae93-7611aa3ee7bb"),
                    Name = "Admin"
                }
            });

            var user = new User
            {
                Id = Guid.Parse("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                Email = "hans.mustermann@email.ch",
                UserName = "hans.mustermann@email.ch",
                NormalizedUserName = "hans.mustermann@email.ch".ToUpper(),
                NormalizedEmail = "hans.mustermann@email.ch".ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                MatriculationNumber = "11-111-11",
                DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                Prename = "Hans",
                Lastname = "Mustermann"
            };

            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Welcome23");
            builder.Entity<User>().HasData(user);

            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                RoleId = Guid.Parse("4c01b50b-3ece-4cdd-9e2e-a3594c14e928")
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
                    Abbreviation = "WACC",
                    EtcsPoints = 6
                },
                new()
                {
                    Id = Guid.Parse("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f"),
                    Name = "Business Information Systems",
                    Description = "An introduction to the role of information systems in modern organizations.",
                    Abbreviation  ="WBIS",
                    EtcsPoints = 6
                },
                new()
                {
                    Id = Guid.Parse("6c381c6f-9d9a-4b69-aa13-33a8a94a1277"),
                    Name = "Grundlagen BWL",
                    Description = "Eine Einführung in die Betriebswirtschaftslehre.",
                    Abbreviation = "WBWL",
                    EtcsPoints= 6
                },
                new()
                {
                    Id = Guid.Parse("e0a6f205-64b7-42ab-bce3-39f0b3841c71"),
                    Name = "Datenmanagement & Datenanalyse",
                    Description = "Eine Einführung in die Verwaltung und Analyse von Daten.",
                    Abbreviation = "WDDA",
                    EtcsPoints = 6
                },
                new()
                {
                    Id = Guid.Parse("480cc771-16a7-4176-8c2b-9a73c1df7b34"),
                    Name = "Digital Enterprise",
                    Description = "An exploration of the impact of digital technologies on business operations.",
                    Abbreviation = "WDEN",
                    EtcsPoints = 6
                },
                new()
                {
                    Id = Guid.Parse("8f0680b7-68c2-4157-aafc-78c72f63a16f"),
                    Name = "English",
                    Description = "Developing proficiency in the English language for business communication.",
                    Abbreviation = "WENG",
                    EtcsPoints = 6
                },
                new()
                {
                    Id = Guid.Parse("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"),
                    Name = "Grundlagen WI",
                    Description = "Introduction to the basics of business informatics.",
                    Abbreviation = "WGWI",
                    EtcsPoints = 6
                },
                new()
                {
                    Id = Guid.Parse("686e6a0c-7f51-4c9d-b968-f6ba201df221"),
                    Name = "Kommunikation",
                    Description = "Effective communication in a business environment.",
                    Abbreviation ="WKOM",
                    EtcsPoints = 3
                },
                new()
                {
                    Id = Guid.Parse("6cb76b54-5f27-4b6d-936d-8f6d7b77ce68"),
                    Name = "Projektmanagement",
                    Description = "Managing projects from start to finish with an emphasis on planning, execution, and control.",
                    Abbreviation = "WPR1",
                    EtcsPoints = 3
                },
                new()
                {
                    Id = Guid.Parse("2aa07a0c-7f51-4c9d-b968-f6ba201df221"),
                    Name = "Business Case Studies",
                    Description = "Analysis and evaluation of real-world business cases to gain insights and develop problem-solving skills.",
                    Abbreviation = "BBCS",
                    EtcsPoints = 6
                },
                new()
                {
                    Id = Guid.Parse("eb2dbecc-d0d6-44ef-82eb-34284633ef19"),
                    Name = "Innovation & Entrepreneurship",
                    Description = "Innovation is the process of developing new ideas, products, services, or processes that create value for customers. ntrepreneurship is the process of creating or starting a new business venture in order to make a profit.",
                    Abbreviation = "WIEN",
                    EtcsPoints = 3
                },
                new()
                {
                    Id = Guid.Parse("7eaf3d1c-f214-4115-892b-8e1f1675897b"),
                    Name = "Domain Driven Design",
                    Description = "Domain Driven Design is an approach to software development that focuses on understanding and modeling the business domain of an application.",
                    Abbreviation = "WDDD",
                    EtcsPoints = 6
                },
                new()
                {
                    Id = Guid.Parse("19b1c514-fb71-414a-8e0a-1f708e1e136e"),
                    Name = "Web Engineering",
                    Description = "Web engineering is the process of designing, developing, testing, and maintaining web applications.",
                    Abbreviation = "WWEN",
                    EtcsPoints = 6,
                }
            });

            builder.Entity("ModulSemesterTimeSlot").HasData(new object[] {
                // WACC -> Every Semester
                new { SemesterTimeSlotId = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835"), ModulId = Guid.Parse("f8ccaae7-014d-4ba7-8c24-4249be07b1c1") },
                new { SemesterTimeSlotId = Guid.Parse("49de8d00-7b44-4180-ac26-3e919bbeb658"), ModulId = Guid.Parse("f8ccaae7-014d-4ba7-8c24-4249be07b1c1") },
                // WBIS -> Every Semester
                new { SemesterTimeSlotId = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835"), ModulId = Guid.Parse("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f") },
                new { SemesterTimeSlotId = Guid.Parse("49de8d00-7b44-4180-ac26-3e919bbeb658"), ModulId = Guid.Parse("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f") },
                // WBWL -> Only Autumn Semester
                new { SemesterTimeSlotId = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835"), ModulId = Guid.Parse("6c381c6f-9d9a-4b69-aa13-33a8a94a1277") },
                // WDDA -> Every Semester
                new { SemesterTimeSlotId = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835"), ModulId = Guid.Parse("e0a6f205-64b7-42ab-bce3-39f0b3841c71") },
                new { SemesterTimeSlotId = Guid.Parse("49de8d00-7b44-4180-ac26-3e919bbeb658"), ModulId = Guid.Parse("e0a6f205-64b7-42ab-bce3-39f0b3841c71") },
                // WDEN -> Only Spring Semester
                new { SemesterTimeSlotId = Guid.Parse("49de8d00-7b44-4180-ac26-3e919bbeb658"), ModulId = Guid.Parse("480cc771-16a7-4176-8c2b-9a73c1df7b34") },
                // WENG -> Every Semester
                new { SemesterTimeSlotId = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835"), ModulId = Guid.Parse("8f0680b7-68c2-4157-aafc-78c72f63a16f") },
                new { SemesterTimeSlotId = Guid.Parse("49de8d00-7b44-4180-ac26-3e919bbeb658"), ModulId = Guid.Parse("8f0680b7-68c2-4157-aafc-78c72f63a16f") },
                // WKOM -> Every Semester
                new { SemesterTimeSlotId = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835"), ModulId = Guid.Parse("686e6a0c-7f51-4c9d-b968-f6ba201df221") },
                new { SemesterTimeSlotId = Guid.Parse("49de8d00-7b44-4180-ac26-3e919bbeb658"), ModulId = Guid.Parse("686e6a0c-7f51-4c9d-b968-f6ba201df221") },
                // WPR1 -> Only Autumn Semester
                new { SemesterTimeSlotId = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835"), ModulId = Guid.Parse("6cb76b54-5f27-4b6d-936d-8f6d7b77ce68") },
                // BBCS -> Only Spring Semester
                new { SemesterTimeSlotId = Guid.Parse("49de8d00-7b44-4180-ac26-3e919bbeb658"), ModulId = Guid.Parse("2aa07a0c-7f51-4c9d-b968-f6ba201df221") },
                // WIEN -> Every Semester
                new { SemesterTimeSlotId = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835"), ModulId = Guid.Parse("eb2dbecc-d0d6-44ef-82eb-34284633ef19") },
                new { SemesterTimeSlotId = Guid.Parse("49de8d00-7b44-4180-ac26-3e919bbeb658"), ModulId = Guid.Parse("eb2dbecc-d0d6-44ef-82eb-34284633ef19") },
                // WDDD -> Only Autumn Semester
                new { SemesterTimeSlotId = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835"), ModulId = Guid.Parse("7eaf3d1c-f214-4115-892b-8e1f1675897b") },
                // BBCS -> Only Spring Semester
                new { SemesterTimeSlotId = Guid.Parse("49de8d00-7b44-4180-ac26-3e919bbeb658"), ModulId = Guid.Parse("19b1c514-fb71-414a-8e0a-1f708e1e136e") },
                // WGWI -> Only Autumn Semester
                new { SemesterTimeSlotId = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835"), ModulId = Guid.Parse("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864") },
            });

            builder.Entity<DegreeModul>().HasData(new List<DegreeModul>()
            {
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    ModulId = Guid.Parse("f8ccaae7-014d-4ba7-8c24-4249be07b1c1"),
                    IsRequired = true,
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = true,
                    ModulId = Guid.Parse("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = true,
                    ModulId = Guid.Parse("6c381c6f-9d9a-4b69-aa13-33a8a94a1277")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = true,
                    ModulId = Guid.Parse("e0a6f205-64b7-42ab-bce3-39f0b3841c71")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = true,
                    ModulId = Guid.Parse("480cc771-16a7-4176-8c2b-9a73c1df7b34")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = true,
                    ModulId = Guid.Parse("8f0680b7-68c2-4157-aafc-78c72f63a16f")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = true,
                    ModulId = Guid.Parse("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = true,
                    ModulId = Guid.Parse("686e6a0c-7f51-4c9d-b968-f6ba201df221")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = true,
                    ModulId = Guid.Parse("6cb76b54-5f27-4b6d-936d-8f6d7b77ce68")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = true,
                    ModulId = Guid.Parse("2aa07a0c-7f51-4c9d-b968-f6ba201df221")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = false,
                    ModulId = Guid.Parse("eb2dbecc-d0d6-44ef-82eb-34284633ef19")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = false,
                    ModulId = Guid.Parse("7eaf3d1c-f214-4115-892b-8e1f1675897b")
                },
                new()
                {
                    DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                    IsRequired = false,
                    ModulId = Guid.Parse("19b1c514-fb71-414a-8e0a-1f708e1e136e")
                },
            });

            builder.Entity<SemesterPlanner>().HasData(new List<SemesterPlanner>
            {
                new()
                {
                    Id = Guid.Parse("efc28c5e-8908-492e-a6f5-1c7396ab6f02"),
                    UserId = Guid.Parse("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                    SemesterId = Guid.Parse("7879d617-ca43-482e-9377-fbd55e2976fa"),
                    SemesterTimeSlotId = Guid.Parse("fae91ab6-7b25-4c5d-bd40-16a79036c835")
                },
                new()
                {
                    Id = Guid.Parse("ee8cdf72-5bea-43c2-a905-3c80192782d1"),
                    UserId = Guid.Parse("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                    SemesterId = Guid.Parse("26082676-ac5f-4a34-bfea-cebba3889b1f"),
                    SemesterTimeSlotId = Guid.Parse("49de8d00-7b44-4180-ac26-3e919bbeb658")
                }
            });

            builder.Entity<SemesterPlannerModul>().HasData(new List<SemesterPlannerModul>() {
                new()
                {
                    SemesterPlannerId = Guid.Parse("efc28c5e-8908-492e-a6f5-1c7396ab6f02"),
                    ModulId = Guid.Parse("6c381c6f-9d9a-4b69-aa13-33a8a94a1277"), // WBWL
                },
                new()
                {
                    SemesterPlannerId = Guid.Parse("efc28c5e-8908-492e-a6f5-1c7396ab6f02"),
                    ModulId = Guid.Parse("686e6a0c-7f51-4c9d-b968-f6ba201df221"), // WKOM
                },
                new()
                {
                    SemesterPlannerId = Guid.Parse("efc28c5e-8908-492e-a6f5-1c7396ab6f02"),
                    ModulId = Guid.Parse("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864") // WGWI
                },
                new()
                {
                    SemesterPlannerId = Guid.Parse("ee8cdf72-5bea-43c2-a905-3c80192782d1"),
                    ModulId = Guid.Parse("e0a6f205-64b7-42ab-bce3-39f0b3841c71") // WDDA
                },
                new()
                {
                    SemesterPlannerId = Guid.Parse("ee8cdf72-5bea-43c2-a905-3c80192782d1"),
                    ModulId = Guid.Parse("19b1c514-fb71-414a-8e0a-1f708e1e136e") // WWEN
                },
                new()
                {
                    SemesterPlannerId = Guid.Parse("ee8cdf72-5bea-43c2-a905-3c80192782d1"),
                    ModulId = Guid.Parse("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f") // WBIS
                },
                new()
                {
                    SemesterPlannerId = Guid.Parse("ee8cdf72-5bea-43c2-a905-3c80192782d1"),
                    ModulId = Guid.Parse("8f0680b7-68c2-4157-aafc-78c72f63a16f") // WENG
                }
            });
            #endregion

        }
    }
}
