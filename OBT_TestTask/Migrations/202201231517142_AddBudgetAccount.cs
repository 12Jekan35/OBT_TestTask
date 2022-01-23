namespace OBT_TestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBudgetAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.BudgetAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        FormNumber = c.Int(nullable: false),
                        SintAccount = c.String(),
                        KOSGU = c.String(),
                        StartYearDebtID = c.Int(nullable: false),
                        ChangeUpDebtID = c.Int(nullable: false),
                        ChangeDownDebtID = c.Int(nullable: false),
                        EndReportPeriodDebtID = c.Int(nullable: false),
                        EndSamePastPeriodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("public.ChangesDebt", t => t.ChangeDownDebtID, cascadeDelete: true)
                .ForeignKey("public.ChangesDebt", t => t.ChangeUpDebtID, cascadeDelete: true)
                .ForeignKey("public.Debts", t => t.EndReportPeriodDebtID, cascadeDelete: true)
                .ForeignKey("public.Debts", t => t.EndSamePastPeriodID, cascadeDelete: true)
                .ForeignKey("public.Debts", t => t.StartYearDebtID, cascadeDelete: true)
                .Index(t => t.StartYearDebtID)
                .Index(t => t.ChangeUpDebtID)
                .Index(t => t.ChangeDownDebtID)
                .Index(t => t.EndReportPeriodDebtID)
                .Index(t => t.EndSamePastPeriodID);
            
            CreateTable(
                "public.ChangesDebt",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AllSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NonmonetaryPart = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "public.Debts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AllSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LongTerm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Overdue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.BudgetAccounts", "StartYearDebtID", "public.Debts");
            DropForeignKey("public.BudgetAccounts", "EndSamePastPeriodID", "public.Debts");
            DropForeignKey("public.BudgetAccounts", "EndReportPeriodDebtID", "public.Debts");
            DropForeignKey("public.BudgetAccounts", "ChangeUpDebtID", "public.ChangesDebt");
            DropForeignKey("public.BudgetAccounts", "ChangeDownDebtID", "public.ChangesDebt");
            DropIndex("public.BudgetAccounts", new[] { "EndSamePastPeriodID" });
            DropIndex("public.BudgetAccounts", new[] { "EndReportPeriodDebtID" });
            DropIndex("public.BudgetAccounts", new[] { "ChangeDownDebtID" });
            DropIndex("public.BudgetAccounts", new[] { "ChangeUpDebtID" });
            DropIndex("public.BudgetAccounts", new[] { "StartYearDebtID" });
            DropTable("public.Debts");
            DropTable("public.ChangesDebt");
            DropTable("public.BudgetAccounts");
        }
    }
}
