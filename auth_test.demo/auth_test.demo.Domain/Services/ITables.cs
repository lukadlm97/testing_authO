using auth_test.demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace auth_test.demo.Domain.Services
{
    public interface ITables
    {
        TablePlace AddNewTable(TablePlace table, int venueId);
        bool DeleteTable(int venueId, int tableId);
        TablePlace UpdatedTable(int venueId, int tableId, TablePlace table);
    }
}
