using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemExTest.Models
{
    public class Product
    {
        [DisplayName("Артикул")]
        public int Id { get; set; }

        [Browsable(false)]
        public int ProductTypeId { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Название не должно быть пустым")]
        public string Name { get; set; }

        [DisplayName("Мин. стоимость")]
        [Required(ErrorMessage = "Мин. стоимость не должна быть пустой")]
        [Range(0.01, float.MaxValue, ErrorMessage = "Мин. стоимость должна быть больше 0")]
        public float MinPrice { get; set; }

        [DisplayName("Себестоимость")]
        public float PriceReal { get; set; }

        [DisplayName("Размер упаковки")]
        public string SizeYpak { get; set; }

        [DisplayName("Вес без упаковки")]
        public float WeightWithOutYpak {get; set;}

        [DisplayName("Вес с упаковкой")]
        public float WeightWithYpak { get; set; }

        [DisplayName("Время изготовления (ч)")]
        public int HoursCreating { get; set; }

        [DisplayName("Номер цеха")]
        public int NumberChex { get; set; }

        [DisplayName("Человек в цеху")]
        public int AmountPeopleChex { get; set; }

        [Browsable(false)]
        public ProductType? ProductType { get; set; } = null;
    }
}
