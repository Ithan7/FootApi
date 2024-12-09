using Microsoft.AspNetCore.Mvc;
using Foot.Tools;
using Foot.API.Models;

namespace Foot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootController : ControllerBase
    {
        private readonly Call _call;

        // Constructeur
        public FootController()
        {
            _call = new Call();
        }

        /// <summary>
        /// Récupère la liste des compétitions de football.
        /// </summary>
        /// <returns>Retourne les informations des compétitions.</returns>
        [HttpGet]
        public ActionResult<FootCompetitions> GetCompetitions()
        {
            ActionResult result;
            try
            {
                // URL de l'API qui fournit les données des compétitions de football.
                var url = "https://api.football-data.org/v2/competitions";
                // Utilisation de la méthode générique pour récupérer et désérialiser les données en un objet Foot.
                var competitionsFoot = _call.GetFromApi<Tools.Foot>(url);
                // Création d'un nouvel objet FootCompetitions et insertion des compétitions récupérées.
                var competitions = new Models.FootCompetitions
                {
                    competitions = competitionsFoot.competitions
                };
                // Retour de l'objet FootCompetitions contenant la liste des compétitions.
                result = Ok(competitions);
            }
            catch (Exception ex) 
            {
                result = BadRequest(ex.Message);
            }
            return result;
        }
    }
}
