////////////////////////////////////////////////////////////////////////////////
//
// The content of this file is copyright (C) 2016 Geoplan
//
//
// Name : WcfServiceErrorHandler.cs
// Creation date: 20 Oct 2016
// Created by : alastair todd
// Comments : 
//

using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Skin.Framework.Logging.Wcf
{
    /// <summary>
    /// An error handler to tell ELMAH about the problem.
    /// </summary>
    public class WcfServiceErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return false;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error != null) // Notify ELMAH of the exception.
            {
                if (System.Web.HttpContext.Current == null)
                    return;
                global::Elmah.ErrorSignal.FromCurrentContext().Raise(error);
            }
        }
    }
}
