using MoneyMgmt.Common.BLL;
using MoneyMgmt.Common.Response;
using MoneyMgmt.DAL;
using MoneyMgmt.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyMgmt.BLL
{
    public class RecordService : GenericService<RecordRepository, Record>
    {
        public RecordService()
        {

        }

        public override SingleResponse Read(int id)
        {
            var res = new SingleResponse();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
    }
}
