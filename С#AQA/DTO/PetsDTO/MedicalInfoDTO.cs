using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.PetsDTO
{
    public record MedicalInfoDTO
        (
            bool Vaccinated,
            bool SpayedNeutered,
            bool Microchipped,
            bool SpecialNeeds,
            string HealthNotes
        );
}
