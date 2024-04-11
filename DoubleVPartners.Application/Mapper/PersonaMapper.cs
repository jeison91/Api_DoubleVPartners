using DoubleVPartners.Application.DTO.Response;
using DoubleVPartners.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Application.Mapper
{
    public static class PersonaMapper
    {
        public static PersonaResponseDTO? MapDTO(PersonaModel model)
        {
            if (model != null)
                return AttibutesDTO(model);
            return null;
        }

        public static List<PersonaResponseDTO> MapDTOList(List<PersonaModel> model)
        {
            List<PersonaResponseDTO> responseDTOs = new();
            if (model != null)
            {
                foreach (PersonaModel item in model)
                {
                    var fl = AttibutesDTO(item);
                    responseDTOs.Add(fl);
                }
            }
            return responseDTOs;
        }

        private static PersonaResponseDTO AttibutesDTO(PersonaModel model)
        {
            if (model != null)
            {
                return new PersonaResponseDTO()
                {
                    Identificacion = model.Identificacion,
                    TipoIdentificacion = model.tipoIdentificacion.Descripcion,
                    NombreCompleto = model.NombreCompleto,
                    Email = model.Email,
                    FechaCreacion = model.FechaCreacion
                };
            }
            return new PersonaResponseDTO();
        }
    }
}
