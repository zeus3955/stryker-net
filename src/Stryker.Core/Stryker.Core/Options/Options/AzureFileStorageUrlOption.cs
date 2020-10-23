﻿using Stryker.Core.Baseline;
using Stryker.Core.Exceptions;
using System;

namespace Stryker.Core.Options.Options
{
    public class AzureFileStorageUrlOption : BaseStrykerOption<string>
    {
        public AzureFileStorageUrlOption(string azureFileStorageUrl, BaselineProvider baselineProvider)
        {
            if (baselineProvider == BaselineProvider.AzureFileStorage && azureFileStorageUrl == null)
            {
                throw new StrykerInputException("The azure file storage url is required when Azure File Storage is enabled.");
            }

            if (!Uri.IsWellFormedUriString(azureFileStorageUrl, UriKind.Absolute))
            {
                throw new StrykerInputException("The azure file storage url is not a valid Uri: {0}", azureFileStorageUrl);
            }

            Value = azureFileStorageUrl;
        }

        public override StrykerOption Type => StrykerOption.AzureFileStorageSas;

        public override string HelpText => @"The url for the Azure File Storage, only needed when the azure baseline provider is selected. 
                                    The url should look something like this: 

                                    https://STORAGE_NAME.file.core.windows.net/FILE_SHARE_NAME 

                                    Note, the url might be different depending of where your file storage is hosted.";

        public override string DefaultValue => null;
    }
}
