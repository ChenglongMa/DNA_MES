// ****************************************************
//  Author: Charles Ma
//  Date: 2018/03/03 21:48
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using DnaMesModel;
using DnaMesModel.Model.BasicInfo;
using Infragistics.Win.UltraWinTree;

namespace DnaMesUiBll.Shared
{
    public interface ITree<T> where T:BaseModel
    {
        void BuildSubTree(UltraTreeNode root, List<T> dataSource, ImagesCollection images);
    }
}