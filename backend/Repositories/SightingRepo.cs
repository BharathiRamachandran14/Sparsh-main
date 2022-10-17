using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhaleSpotting.Models.Database;

namespace WhaleSpotting.Repositories
{
    public interface ISightingRepo
    {
        IEnumerable<Sighting> GetApprovedSightings();
        IEnumerable<Sighting> GetSightingsBySpeciesId(int speciesId);
        IEnumerable<Sighting> GetPendingSightings();
        Sighting CreateSighting(Sighting createSightingRequest);
        bool ConfirmRequest(int SightingId);
        bool RejectRequest(int SightingId);
    }

    public class SightingRepo : ISightingRepo
    {
        private readonly WhaleSpottingDbContext _context;

        public SightingRepo(WhaleSpottingDbContext context)
        {
            _context = context;
        }

        public Sighting CreateSighting(Sighting newSighting)
        {
            var insertedSighting = _context.Sightings.Add(newSighting);
            _context.SaveChanges();

            return insertedSighting.Entity;
        }

        public IEnumerable<Sighting> GetApprovedSightings()
        {
            return _context
                .Sightings
                .Where(s => s.ConfirmationStatus == ConfirmationStatus.Approved);
        }

        public IEnumerable<Sighting> GetPendingSightings()
        {
            return _context.Sightings.Where(s => s.ConfirmationStatus == ConfirmationStatus.Pending);
        }

        public IEnumerable<Sighting> GetSightingsBySpeciesId(int speciesId)
        {
            return _context.Sightings
                .Include(s => s.Species)
                .Include(s => s.Location)
                .Where(s => s.Species.Id == speciesId)
                .Where(s => s.ConfirmationStatus == ConfirmationStatus.Approved)
                .OrderByDescending(s => s.SeenOn);
        }
        public bool ConfirmRequest(int SightingId)
        {
            var sighting = _context.Sightings.Find(SightingId);
            if (sighting != null)
            {
                sighting.ConfirmationStatus = ConfirmationStatus.Approved;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool RejectRequest(int SightingId)
        {
            var sighting = _context.Sightings.Find(SightingId);
            if (sighting != null)
            {
                sighting.ConfirmationStatus = ConfirmationStatus.Rejected;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
