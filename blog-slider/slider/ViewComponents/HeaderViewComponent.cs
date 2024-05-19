﻿using Microsoft.AspNetCore.Mvc;
using slider.Services.Interface;

namespace slider.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;
        public HeaderViewComponent(ISettingService settingService)
        {
            _settingService = settingService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            return await Task.FromResult(View(await _settingService.GetALLAsync()));

        }
    }
}
