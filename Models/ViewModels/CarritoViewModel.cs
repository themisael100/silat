using System;

namespace silat.Models.ViewModels;

public class CarritoViewModel
{
    List<CarritoItemViewModel> Items { get; set; } = new List<CarritoItemViewModel>();
    public decimal Total { get; set; }
}
