﻿using System.Collections.Generic;
using Orchard.ContentManagement.Metadata.Models;
using Orchard.ContentManagement.ViewModels;

namespace Orchard.ContentTypes.ViewModels {
    public class EditPartFieldViewModel {

        public EditPartFieldViewModel() {
            Settings = new SettingsDictionary();
        }

        public EditPartFieldViewModel(int index, ContentPartFieldDefinition field) {
            Index = index;
            Name = field.Name;
            FieldDefinition = new EditFieldViewModel(field.FieldDefinition);
            Settings = field.Settings;
            _Definition = field;
        }

        public int Index { get; set; }
        public string Prefix { get { return "Fields[" + Index + "]"; } }
        public EditPartViewModel Part { get; set; }

        public string Name { get; set; }
        public IEnumerable<TemplateViewModel> Templates { get; set; }
        public EditFieldViewModel FieldDefinition { get; set; }
        public SettingsDictionary Settings { get; set; }
        public ContentPartFieldDefinition _Definition { get; private set; }
    }
}