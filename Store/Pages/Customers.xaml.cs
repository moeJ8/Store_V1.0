using Store.Models;
using Store.Services;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Store;

public partial class Customers : ContentPage
{
    private readonly DatabaseService _databaseService;
    public Customers(DatabaseService databaseService)
	{
		InitializeComponent();
        _databaseService = databaseService;
	}

    protected async Task LoadCustomers()
    {
        List<Customer> customers = await _databaseService.GetCustomersAsync();
        CustomerListView.ItemsSource = customers;
    }

   /* private async void OnAddCustomerClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Customer_Detail(new Customer(), _databaseService));
    }

    private async void OnCustomerSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new Customer_Detail(e.SelectedItem as Customer, _databaseService));
        }
    }*/
}