﻿using Coldairarrow.Business.Base_Manage;
using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Base_Manage
{
    [Route("/Base_Manage/[controller]/[action]")]
    public class Base_LogController : BaseApiController
    {
        #region DI

        public Base_LogController(IBase_LogBusiness logBus)
        {
            _logBus = logBus;
        }

        IBase_LogBusiness _logBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<AjaxResult<List<Base_Log>>> GetLogList(
            Pagination pagination,
            string logContent,
            string logType,
            string level,
            string opUserName,
            DateTime? startTime,
            DateTime? endTime)
        {
            pagination.SortField = "CreateTime";
            pagination.SortType = "desc";
            var list = await _logBus.GetLogListAsync(pagination, logContent, logType, level, opUserName, startTime, endTime);

            return DataTable(list, pagination);
        }

        [HttpPost]
        public AjaxResult<List<SelectOption>> GetLogTypeList()
        {
            var list = EnumHelper.ToOptionList(typeof(LogType));

            return Success(list);
        }

        [HttpPost]
        public AjaxResult<List<SelectOption>> GetLoglevelList()
        {
            var list = EnumHelper.ToOptionList(typeof(LogLevel));

            return Success(list);
        }

        #endregion

        #region 提交

        #endregion
    }
}