﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult delete(Color color);
        IResult update(Color color);
        IDataResult<Color> GetColorById(int colorId);
        IDataResult<List<Color>> GetAll();
    }
}
