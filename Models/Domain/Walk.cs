﻿namespace EgyptWalks.Models.Domain
{
    public class Walk
    {

        public Guid Id { get; set; }    

        public string Name { get; set; }    

        public string Description { get; set; } 

        public double LengthInKm { get; set; }  

        public string?  WalkImageUrl { get; set; }

        
        public Guid DiffucltyId { get; set; }
        public Diffuclty Diffuclty { get; set; }

        public Guid RegionId { get; set; }

        public Region Region { get; set; }
    }
}
