﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        List<Comment> GetComments(int id);
        List<Comment> TGetListWithDestinations();
        List<Comment> TGetListWithDestinationAndUser(int id);

    }
}