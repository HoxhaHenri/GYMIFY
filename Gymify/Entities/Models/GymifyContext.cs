using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class GymifyContext : DbContext
    {
        public GymifyContext()
        {
        }

        public GymifyContext(DbContextOptions<GymifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<Coach> Coaches { get; set; } = null!;
        public virtual DbSet<CoachContract> CoachContracts { get; set; } = null!;
        public virtual DbSet<Complaint> Complaints { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<EquipmentRequest> EquipmentRequests { get; set; } = null!;
        public virtual DbSet<Exercise> Exercises { get; set; } = null!;
        public virtual DbSet<FrontDesk> FrontDesks { get; set; } = null!;
        public virtual DbSet<Gym> Gyms { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<MemberRating> MemberRatings { get; set; } = null!;
        public virtual DbSet<Membership> Memberships { get; set; } = null!;
        public virtual DbSet<MembershipMember> MembershipMembers { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Photo> Photos { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Video> Videos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HRUD03R\\SQLEXPRESS;Database=Gymify;Trusted_Connection=True");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Administ__1788CC4C3E988D12");

                entity.ToTable("Administrator");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Administrators)
                    .HasPrincipalKey(p => new { p.UserId, p.Role })
                    .HasForeignKey(d => new { d.UserId, d.Role })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_administrator");
            });

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Coach__1788CC4C4C2AE03B");

                entity.ToTable("Coach");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Coaches)
                    .HasPrincipalKey(p => new { p.UserId, p.Role })
                    .HasForeignKey(d => new { d.UserId, d.Role })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_coach");
            });

            modelBuilder.Entity<CoachContract>(entity =>
            {
                entity.HasKey(e => new { e.CoachId, e.GymId })
                    .HasName("coachcontracts_pk");

                entity.Property(e => e.Salary).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.CoachContracts)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoachCont__Coach__70DDC3D8");

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.CoachContracts)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoachCont__GymId__71D1E811");
            });

            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.ToTable("Complaint");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Type).HasMaxLength(200);

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Complaint__GymId__628FA481");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Complaint__UserI__6383C8BA");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course__CoachId__47DBAE45");

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_course_gym");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Availability).HasMaxLength(1);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__GymId__5070F446");
            });

            modelBuilder.Entity<EquipmentRequest>(entity =>
            {
                entity.HasKey(e => new { e.EquipmentId, e.CoachId })
                    .HasName("equipmentrequest_pk");

                entity.ToTable("EquipmentRequest");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.EquipmentRequests)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Coach__7D439ABD");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentRequests)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Equip__7C4F7684");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.ToTable("Exercise");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Equipment)
                    .WithMany(p => p.Exercises)
                    .UsingEntity<Dictionary<string, object>>(
                        "ExerciseEquipment",
                        l => l.HasOne<Equipment>().WithMany().HasForeignKey("EquipmentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ExerciseE__Equip__797309D9"),
                        r => r.HasOne<Exercise>().WithMany().HasForeignKey("ExerciseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ExerciseE__Exerc__787EE5A0"),
                        j =>
                        {
                            j.HasKey("ExerciseId", "EquipmentId").HasName("exerciseequipment_pk");

                            j.ToTable("ExerciseEquipment");
                        });
            });

            modelBuilder.Entity<FrontDesk>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__FrontDes__1788CC4CDF4D582D");

                entity.ToTable("FrontDesk");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.FrontDesks)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gym");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FrontDesks)
                    .HasPrincipalKey(p => new { p.UserId, p.Role })
                    .HasForeignKey(d => new { d.UserId, d.Role })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_frontdesk");
            });

            modelBuilder.Entity<Gym>(entity =>
            {
                entity.ToTable("Gym");

                entity.HasIndex(e => e.ManagerId, "UQ__Gym__3BA2AAE028AEC4C8")
                    .IsUnique();

                entity.HasIndex(e => new { e.Name, e.Location }, "unique_name_location")
                    .IsUnique();

                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.Gyms)
                    .HasForeignKey(d => d.AdministratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Gym__Administrat__440B1D61");

                entity.HasOne(d => d.LogoNavigation)
                    .WithMany(p => p.Gyms)
                    .HasForeignKey(d => d.Logo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gym_logo");

                entity.HasOne(d => d.Manager)
                    .WithOne(p => p.Gym)
                    .HasForeignKey<Gym>(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Gym__ManagerId__4316F928");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Manager__1788CC4C39F37E29");

                entity.ToTable("Manager");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Managers)
                    .HasPrincipalKey(p => new { p.UserId, p.Role })
                    .HasForeignKey(d => new { d.UserId, d.Role })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_manager");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Member__1788CC4C8DCFE6A3");

                entity.ToTable("Member");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Members)
                    .HasPrincipalKey(p => new { p.UserId, p.Role })
                    .HasForeignKey(d => new { d.UserId, d.Role })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user");

                entity.HasMany(d => d.Courses)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "MemberCourse",
                        l => l.HasOne<Course>().WithMany().HasForeignKey("CourseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("membercourse_course_fk"),
                        r => r.HasOne<Member>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("membercourse_member_fk"),
                        j =>
                        {
                            j.HasKey("UserId", "CourseId").HasName("membercourse_pk");

                            j.ToTable("MemberCourse");
                        });
            });

            modelBuilder.Entity<MemberRating>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GymId })
                    .HasName("memberrating_pk");

                entity.ToTable("MemberRating");

                entity.Property(e => e.Rating).HasColumnType("numeric(2, 1)");

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.MemberRatings)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("memberrating_gym_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MemberRatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("memberrating_user_fk");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.ToTable("Membership");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.Type).HasMaxLength(200);

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Membershi__GymId__5FB337D6");
            });

            modelBuilder.Entity<MembershipMember>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MembershipId })
                    .HasName("mm_primarykey");

                entity.ToTable("MembershipMember");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MembershipMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mm_member_fk");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.Content).HasMaxLength(1);

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.MessageReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__Receive__571DF1D5");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.MessageSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__SenderI__5629CD9C");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.NotificationMessage)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.FrontDesk)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.FrontDeskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Front__534D60F1");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo");

                entity.Property(e => e.Description).HasMaxLength(1);

                entity.Property(e => e.Location).HasMaxLength(1);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Session__CourseI__4AB81AF0");

                entity.HasMany(d => d.Exercises)
                    .WithMany(p => p.Sessions)
                    .UsingEntity<Dictionary<string, object>>(
                        "SessionExercise",
                        l => l.HasOne<Exercise>().WithMany().HasForeignKey("ExerciseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__SessionEx__Exerc__75A278F5"),
                        r => r.HasOne<Session>().WithMany().HasForeignKey("SessionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__SessionEx__Sessi__74AE54BC"),
                        j =>
                        {
                            j.HasKey("SessionId", "ExerciseId").HasName("sessionexercise_pk");

                            j.ToTable("SessionExercise");
                        });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Username, "UQ__User__536C85E4CEE34731")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__User__85FB4E38187B3C93")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__User__A9D105347EF1AA09")
                    .IsUnique();

                entity.HasIndex(e => new { e.UserId, e.Role }, "unique_key")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProfilePictureNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ProfilePicture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_profilepic");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("Video");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Location).HasMaxLength(4000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
