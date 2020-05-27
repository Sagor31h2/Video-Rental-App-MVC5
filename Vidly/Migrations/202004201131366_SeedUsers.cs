namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {  Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'11ab5760-b701-4fbd-9a50-27f3bdcdeef8', N'sagor100@gamil.com', 0, N'APTCnyiPO0aNdR1s4tTbRBgs8RaQDa0S6rPxeLjmMT8X1lLnfXs/Q02yU4h3EhP9Ww==', N'f5f081b9-078d-4edd-b1ea-13ca130f85c2', NULL, 0, 0, NULL, 1, 0, N'sagor100@gamil.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3593b01b-5910-482e-ad20-31d3687cdcc5', N'sagor@gamil.com', 0, N'ACHph0SRkBNANQlIycdtZ6v/MmfziIQ06XMFAYTBX8sBD+qKjkrKLOFuRmqSTXdDQg==', N'ba423409-ce82-48ff-94db-abb7935a057b', NULL, 0, 0, NULL, 1, 0, N'sagor@gamil.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a524761e-9fa7-4341-821e-6f4145a3e070', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'11ab5760-b701-4fbd-9a50-27f3bdcdeef8', N'a524761e-9fa7-4341-821e-6f4145a3e070')
");
        }
        
        public override void Down()
        {
        }
    }
}
