// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 14:04
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaMesDal;
using DnaMesModel.Model;

namespace DnaMesBll
{
    public abstract class BaseBll<T>:BaseDal<T> where T:BaseModel,new()
    {

    }
}