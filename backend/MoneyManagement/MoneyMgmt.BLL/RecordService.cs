﻿using MoneyMgmt.Common.BLL;
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


        public SingleResponse GetRecordsByUserId(int userId)
        {
            var res = new SingleResponse();
            var m = _rep.GetRecordsByUserId(userId);
            res.Data = m;
            return res;
        }

        public SingleResponse CreateRecordByUser(Record record, int userId, int categoryId, int accountId)
        {
            var res = new SingleResponse();

            bool result = _rep.CreateRecordByUser(record, userId, categoryId, accountId);

            if (result)
            {
                res.Code = "201";
                res.SetMessage("Create successfully");
            }
            else
            {
                res.SetError(code: "400", message: "Create failed");
            }

            return res;
        }

        public SingleResponse UpdateRecordByUser(Record record, int userId, int categoryId, int accountId)
        {
            var res = new SingleResponse();
            bool result = _rep.UpdateRecordByUser(record, userId, categoryId, accountId);

            if (result)
            {
                res.Code = "200";
                res.SetMessage("Update successfully");
            }
            else
            {
                res.SetError(code: "400", message: "Update failed");
            }

            return res;
        }

        public SingleResponse HardDeleteRecordByUser(int recordId, int userId)
        {
            var res = new SingleResponse();
            bool result = _rep.HardDeleteRecordByUser(recordId: recordId, userId: userId);

            if (result)
            {
                res.Code = "200";
                res.SetMessage("Delete successfully");
            }
            else
            {
                res.SetError(code: "400", message: "Delete failed");
            }

            return res;
        }
    }
}
