using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bodea_Denis.Data;
namespace Bodea_Denis.Models
{
    public class MasinaDotariPageModel:PageModel
    {
        public List<AssignedDotareData> AssignedDotareDataList;
        public void PopulateAssignedDotareData(Bodea_DenisContext context, Masina masina) {
            var allDotari = context.Dotare; 
            var masinaDotari = new HashSet<int>(masina.MasinaDotari.Select(c => c.MasinaID));
            AssignedDotareDataList = new List<AssignedDotareData>();
            foreach (var dot in allDotari) { 
                AssignedDotareDataList.Add(new AssignedDotareData{
                    DotareID = dot.ID,Nume = dot.DotareNume,Assigned = masinaDotari.Contains(dot.ID)}); } }
        public void UpdateMasinaDotari(Bodea_DenisContext context, string[] selectedDotari, Masina masinaToUpdate)
        {
            if (selectedDotari == null) {
                masinaToUpdate.MasinaDotari = new List<MasinaDotare>();
                return; }
            var selectedDotariHS = new HashSet<string>(selectedDotari);
            var masinaDotari = new HashSet<int>(masinaToUpdate.MasinaDotari.Select(c => c.Dotare.ID));
            foreach (var dot in context.Dotare) {
                if (selectedDotariHS.Contains(dot.ID.ToString())) {
                    if (!masinaDotari.Contains(dot.ID)) {
                        masinaToUpdate.MasinaDotari.Add(new MasinaDotare{
                            MasinaID = masinaToUpdate.ID,
                            DotareID = dot.ID});
                    }
                } else {
                    if (masinaDotari.Contains(dot.ID)) { 
                        MasinaDotare courseToRemove = masinaToUpdate.MasinaDotari.SingleOrDefault(i => i.DotareID == dot.ID);
                        context.Remove(courseToRemove); 
                    }
                }
            }
        }
    }
}
