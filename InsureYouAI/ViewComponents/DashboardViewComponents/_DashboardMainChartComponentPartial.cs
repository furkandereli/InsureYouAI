using InsureYouAI.Context;
using InsureYouAI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DashboardViewComponents;

public class _DashboardMainChartComponentPartial(InsureContext context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var revenueData = context.Revenues
                .GroupBy(r => r.ProcessDate.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    TotalAmount = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.Month)
                .ToList();

        //Expense
        var expenseData = context.Expenses
            .GroupBy(e => e.ProcessDate.Month)
            .Select(g => new
            {
                Month = g.Key,
                TotalAmount = g.Sum(x => x.Amount)
            })
            .OrderBy(x => x.Month)
            .ToList();

        //All Months
        var allMonths = revenueData.Select(x => x.Month)
            .Union(expenseData.Select(y => y.Month))
            .OrderBy(x => x)
            .ToList();

        var model = new RevenueExpenseChartViewModel()
        {
            Months = allMonths.Select(x => new System.Globalization.DateTimeFormatInfo().GetAbbreviatedMonthName(x)).ToList(),
            RevenueTotals = allMonths.Select(m => revenueData.FirstOrDefault(x => x.Month == m)?.TotalAmount ?? 0).ToList(),
            ExpenseTotals = allMonths.Select(m => expenseData.FirstOrDefault(x => x.Month == m)?.TotalAmount ?? 0).ToList()
        };

        ViewBag.v1 = context.Revenues.Sum(x => x.Amount);
        ViewBag.v2 = context.Expenses.Sum(x => x.Amount);

        return View(model);
    }
}
