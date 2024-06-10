using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.ViewModel
{
    public class ClaseResumen
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string? NombreColor { get; set; }
        public List<ClaseHija>? Hijas { get; set; }
    }

    public class ClaseHija
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? Nombre { get; set; }
        public int Edad { get; set; }
    }
}
