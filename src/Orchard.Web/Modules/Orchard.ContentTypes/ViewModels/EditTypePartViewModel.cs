﻿using System.Collections.Generic;
using Orchard.ContentManagement.Metadata.Models;
using Orchard.ContentManagement.ViewModels;

namespace Orchard.ContentTypes.ViewModels {
    public class EditTypePartViewModel {
        public EditTypePartViewModel() {
            Settings = new SettingsDictionary();
        }

        public EditTypePartViewModel(int index, ContentTypePartDefinition part) {
            Index = index;
            PartDefinition = new EditPartViewModel(part.PartDefinition);
            Settings = part.Settings;
            _Definition = part;
        }

        public int Index { get; set; }
        public string Prefix { get { return "Parts[" + Index + "]"; } }
        public EditPartViewModel PartDefinition { get; set; }
        public SettingsDictionary Settings { get; set; }
        public EditTypeViewModel Type { get; set; }
        public IEnumerable<TemplateViewModel> Templates { get; set; }
        public ContentTypePartDefinition _Definition { get; private set; }
    }
}