using auth_test.demo.Domain.Models;
using auth_test.demo.Domain.Services;
using auth_test.demo.Entityframework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auth_test.demo.Services
{
    public class TablesService : ITables
    {
        private readonly AuthContext _context;

        public TablesService(AuthContext context)
        {
            _context = context;
        }

        public TablePlace AddNewTable(TablePlace table, int venueId)
        {
            try
            {
                var venue = _context.Venues
                                            .SingleOrDefault(v => v.Id == venueId);

                var tables = venue.Tables.ToList();
                tables.Add(table);
                venue.Tables = tables;

                _context.Set<Venue>().Update(venue);
                _context.SaveChanges();

                return table;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public bool DeleteTable(int venueId, int tableId)
        {
            try
            {
                var venue = _context.Venues
                                                  .SingleOrDefault(v => v.Id == venueId);

                var tables = venue.Tables.ToList();
                var tableForDeleting = tables.SingleOrDefault(t => t.Id == tableId);

                if (tableForDeleting == null)
                    return false;

                tables.Remove(tableForDeleting);
                venue.Tables = tables;

                _context.Set<Venue>().Update(venue);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public TablePlace UpdatedTable(int venueId, int tableId, TablePlace table)
        {
            try
            {
                var venue = _context.Venues.SingleOrDefault(v => v.Id == venueId);

                var tables = venue.Tables.ToList();
                var tableForUpdate = tables.SingleOrDefault(t => t.Id == tableId);

                if (tableForUpdate == null)
                    return null;

                table.Id = tableId;
                tableForUpdate = table;
                venue.Tables = tables;

                _context.Set<Venue>().Update(venue);
                _context.SaveChanges();
                return tableForUpdate;
            }
            catch (Exception e)
            {

                return null;
            }
        }
    
    }
}
