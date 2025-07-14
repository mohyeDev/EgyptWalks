﻿namespace EgyptWalks.Models.DTo
{
    public class WalkDto
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public RegionDto Region { get; set; }   

        public DiffucltyDto Diffuclty { get; set; } 

    }
}
