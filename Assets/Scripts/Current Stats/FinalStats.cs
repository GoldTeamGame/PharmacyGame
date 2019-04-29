using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalStats : MonoBehaviour {
    public Text CashText;
    public Text AccountsReceivableFromSuppliersText;
    public Text InventoryText;
    public Text totalAssetsText;
    public Text AccountsPayableToSuppliersText;
    public Text LongtermLiabilitiesText;
    public Text TotalLiabilitiesText;
    public Text TotalOwnersEquityText;

    public Text SalesText;
    public Text CostOfGoodsSoldText;
    public Text GrossMarginText;
    public Text AdministrativeExpensesText;
    public Text GeneralExpensesText;
    public Text SellingExpensesText;
    public Text OtherExpensesText;
    public Text TotalOperatingExpensesText;
    public Text NetOperatingIncomeBeforeTaxesText;
    public Text OtherIncomeText;
    public Text TotalNetIncomeBeforeTaxesText;
    public Text TaxesText;
    public Text NetIncomeAfterTaxesText;


    public static int InventoryAtBeginningOfMonth;
    public static int PurchasesDuringMonth;
    public static int InventoryAtEndOfMonth;

    // BALANCE SHEET

    // Assets (Current Assets)
    public static int Cash;
    public static int AccountsReceivableFromSuppliers;
    public static int Inventory;
    public static int PropertyPlantEquipment;
    public static int TotalAssets;


    // Cash on hand
    private static void calculateCash()
    {
        Cash = Globals.playerGold;
    }

    // Cash paid from customers in form of credit (assume half the amount made was from credit)
    private static void calculateAccountsReceivableFromSuppliers()
    {
        AccountsReceivableFromSuppliers = Globals.playerGold / 2;
    }

    // Cost of total inventory
    private static void calculateInventory()
    {
        int sum = 0;

        // Calculate total prescription inventory
        for (int i = 0; i < Globals_Items.item[0].Length; i++)
            sum += Globals_Items.item[0][i].price * ((Drug)Globals_Items.item[0][i]).amount;

        // Calculate total over the counter inventory
        for (int i = 0; i < Globals_Items.item[1].Length; i++)
            sum += Globals_Items.item[1][i].price * ((Drug)Globals_Items.item[0][i]).amount;

        Inventory = sum;
    }

    // Long Term Assets (Noncurrent Assets)

    // Value of fixtures/property
    private static void calculatePropertyPlantEquipment()
    {
        int sum = 1000; // assumed value of property

        // Add fixtures that are unlocked to sum
        for (int i = 0; i < Globals_Items.item[5].Length; i++)
            if (Globals_Items.item[5][i].isUnlocked)
                sum += Globals_Items.item[5][i].price;

        PropertyPlantEquipment = sum;
    }

    // Sum of all assets
    private static void calculateTotalAssets()
    {
        TotalAssets = Cash + AccountsReceivableFromSuppliers + Inventory + PropertyPlantEquipment;
    }

    // Liabilities (Current Liabilities)

    public static int AccountsPayableToSuppliers;
    public static int AccruedSalariesPayable;
    public static int LongtermLiabilities;
    public static int TotalLiabilities;

    // Debts from purchasing goods with credit
    private static void calculateAccountsPayableToSuppliers()
    {
        // TODO: Make this a bailout amount (when you are forced to take a loan)
        AccountsPayableToSuppliers = 0;
    }

    // Salaries that will not be paid until next accounting period
    private static void calculateAccruedSalariesPayable()
    {
        int sum = 0;

        // Add all pharmacist salaries
        for (int i = 0; i < Globals_Items.item[2].Length; i++)
            if (Globals_Items.item[2][i].isUnlocked)
                sum += Globals_Items.item[2][i].price;

        AccruedSalariesPayable = sum;
    }

    // Longterm Liabilities (Noncurrent Liabilities)
    // Long Term Loans/Mortgages
    private static void calculateLongtermLiabilities()
    {
        if (Time.frameCount % 1800 == 0)
        {
            LongtermLiabilities = Random.Range(1200, 8000); // Generate random int
        }
    }

    // Sum of all liabilities
    private static void calculateTotalLiabilities()
    {
        TotalLiabilities = AccountsPayableToSuppliers + AccruedSalariesPayable + LongtermLiabilities;
    }

    // Owners' Equity
    public static int CommonStockOutstanding;
    public static int AdditionalPaidInCapitalFromOwners;
    public static int RetainedEarnings;
    public static int TotalOwnersEquity;


    // Value of all stocks held by stockholders
    private static void calculateCommonStockOutstanding()
    {
        int mood = 0;
        // TODO: keep track of mood when customers leave store and add it to an average. The average happiness of store will cause stocks to be higher
        if (Time.frameCount % 1800 == 0)
        {
            CommonStockOutstanding = Random.Range(1400, 5000);
        }
    }

    // Value of all stocks held by Owner of Pharmacy
    private static void calculateAdditionalPaidInCapitalFromOwners()
    {
        AdditionalPaidInCapitalFromOwners = CommonStockOutstanding / 3; // a third of total stocks
    }

    // Profits a business has made during current period of Operation
    private static void calculateRetainedEarnings()
    {
        // Randomize Retained Earnings
        if (Time.frameCount % 1800 == 0)
        {
            RetainedEarnings = TotalAssets;
            RetainedEarnings += Random.Range(0, RetainedEarnings / 5);
            RetainedEarnings -= Random.Range(0, RetainedEarnings / 5);
        }
    }

    // Sum of all owners equity
    private static void calculateTotalOwnersEquity()
    {
        TotalOwnersEquity = CommonStockOutstanding + AdditionalPaidInCapitalFromOwners + RetainedEarnings;
    }

    // Calculate all values relevent to balance sheet
    public static void calculateBalanceSheet()
    {
        calculateCash();
        calculateAccountsReceivableFromSuppliers();
        calculateInventory();
        calculatePropertyPlantEquipment();
        calculateTotalAssets();
        calculateAccountsPayableToSuppliers();
        calculateAccruedSalariesPayable();
        calculateLongtermLiabilities();
        calculateTotalLiabilities();
        calculateCommonStockOutstanding();
        calculateAdditionalPaidInCapitalFromOwners();
        calculateRetainedEarnings();
        calculateTotalOwnersEquity();


    }


    // INCOME STATEMENT
    public static int Sales;
    public static int CostOfGoodsSold;
    public static int GrossMargin;
    public static int AdministrativeExpenses;
    public static int GeneralExpenses;
    public static int SellingExpenses;
    public static int OtherExpenses;
    public static int TotalOperatingExpenses;
    public static int NetOperatingIncomeBeforeTaxes;
    public static int OtherIncome;
    public static int TotalNetIncomeBeforeTaxes;
    public static int Taxes;
    public static int NetIncomeAfterTaxes;

    // Money earned from sales of goods
    private static void calculateSales()
    {
        Sales = Globals.monthlyGold;
    }

    // Expenses incurred when selling product
    private static void calculateCostOfGoodsSold()
    {
        CostOfGoodsSold = InventoryAtBeginningOfMonth + PurchasesDuringMonth + InventoryAtEndOfMonth;
    }

    // Difference between current sales and cost of goods sold
    private static void calculateGrossMargin()
    {
        GrossMargin = Sales - CostOfGoodsSold;
    }

    // Salaries paid to employees
    private static void calculateAdministrativeExpenses()
    {
        AdministrativeExpenses = AccruedSalariesPayable;
    }

    // Cost of property/equipment
    private static void calculateGeneralExpenses()
    {
        int sum = PropertyPlantEquipment;

        // Add 500 to sum for every unlocked pharmacist counter
        for (int i = 0; i < Globals_Pharmacist.pharmacistCounter.Length; i++)
            if (Globals_Pharmacist.pharmacistCounter[i].isUnlocked)
                sum += 500;

        GeneralExpenses = sum;
    }

    // Cost of advertising/marketing
    private static void calculateSellingExpenses()
    {
        // TODO: implement advertising upgrade and reflect cost spent here
        SellingExpenses = 0;
    }

    // Expenses from interest and disposal of fixed assets
    private static void calculateOtherExpenses()
    {
        OtherExpenses = 0;
    }

    // Sum of the 4 above expenses
    private static void calculateTotalOperatingExpenses()
    {
        TotalOperatingExpenses = AdministrativeExpenses + GeneralExpenses + SellingExpenses + OtherExpenses;
    }

    // Difference between gross margin and total operating expenses
    private static void calculateNetOperatingIncomeBeforeTaxes()
    {
        NetOperatingIncomeBeforeTaxes = GrossMargin - TotalOperatingExpenses;
    }

    // Difference between interest-based income and interest based liabilities
    private static void calculateOtherIncome()
    {
        OtherIncome = 0;
    }

    // Sum of net operating income and other income
    private static void calculateTotalNetIncomeBeforeTaxes()
    {
        TotalNetIncomeBeforeTaxes = NetOperatingIncomeBeforeTaxes + OtherIncome;
    }

    // The amount of total net income that is taxed
    private static void calculateTaxes()
    {
        Taxes = TotalNetIncomeBeforeTaxes / 10; // assume tax rate is 10%
    }

    // The amount of total net income after being taxed
    private static void calculateNetIncomeAfterTaxes()
    {
        NetIncomeAfterTaxes = TotalNetIncomeBeforeTaxes - Taxes;
    }

    // Caculate all values for income statement
    public static void calulateIncomeStatement()
    {
        calculateSales();
        calculateCostOfGoodsSold();
        calculateGrossMargin();
        calculateAdministrativeExpenses();
        calculateGeneralExpenses();
        calculateSellingExpenses();
        calculateOtherExpenses();
        calculateTotalOperatingExpenses();
        calculateNetOperatingIncomeBeforeTaxes();
        calculateOtherIncome();
        calculateTotalNetIncomeBeforeTaxes();
        calculateTaxes();
        calculateNetIncomeAfterTaxes();

       
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
            calculateBalanceSheet();
            calulateIncomeStatement();
            CashText.text = Cash.ToString();
            AccountsPayableToSuppliersText.text = AccountsPayableToSuppliers.ToString();
            totalAssetsText.text = TotalAssets.ToString();
            AccountsReceivableFromSuppliersText.text = AccountsReceivableFromSuppliers.ToString();
            InventoryText.text = Inventory.ToString();
            PropertyPlantEquipmentText.text = PropertyPlantEquipment.ToString();
            AccountsPayableToSuppliersText.text = AccountsPayableToSuppliers.ToString();
            LongtermLiabilitiesText.text = LongtermLiabilities.ToString();
            TotalLiabilitiesText.text = TotalLiabilities.ToString();
            TotalOwnersEquityText.text = TotalOwnersEquity.ToString();
            SalesText.text = Sales.ToString();
            CostOfGoodsSoldText.text = CostOfGoodsSold.ToString();
            GrossMarginText.text = GrossMargin.ToString();
            AdministrativeExpensesText.text = AdministrativeExpenses.ToString();
            GeneralExpensesText.text = GeneralExpenses.ToString();
            SellingExpensesText.text = SellingExpenses.ToString();
            OtherExpensesText.text = OtherExpenses.ToString();
            TotalOperatingExpensesText.text = TotalOperatingExpenses.ToString();
            NetOperatingIncomeBeforeTaxesText.text = NetOperatingIncomeBeforeTaxes.ToString();
            OtherIncomeText.text = OtherIncome.ToString();
            TotalNetIncomeBeforeTaxesText.text = TotalNetIncomeBeforeTaxes.ToString();
            TaxesText.text = Taxes.ToString();
            NetIncomeAfterTaxesText.text = NetIncomeAfterTaxes.ToString();

    }
}
