﻿namespace XamlPowerToys.Model.CodeGeneration.Xamarin.Controls {
    using System;
    using System.Text;
    using XamlPowerToys.Model.CodeGeneration.Infrastructure;
    using XamlPowerToys.Model.Infrastructure;
    using XamlPowerToys.Model.XamarinForms;

    public class SliderFactory : IControlFactory {

        readonly ControlTemplateModel<SliderEditorProperties> _model;

        public SliderFactory(GenerateFormModel generateFormModel, PropertyInformationViewModel propertyInformationViewModel) {
            if (generateFormModel == null) {
                throw new ArgumentNullException(nameof(generateFormModel));
            }
            if (propertyInformationViewModel == null) {
                throw new ArgumentNullException(nameof(propertyInformationViewModel));
            }
            _model = new ControlTemplateModel<SliderEditorProperties>(generateFormModel, propertyInformationViewModel);
        }

        public string MakeControl(Int32? parentGridColumn = null, Int32? parentGridRow = null) {
            var sb = new StringBuilder("<Slider ");
            if (!String.IsNullOrWhiteSpace(_model.BindingPath)) {
                sb.AppendFormat("Value=\"{0}\" ", Helpers.ConstructBinding(_model.BindingPath, _model.BindingMode, _model.StringFormatText, _model.BindingConverter));
            }

            if (!String.IsNullOrWhiteSpace(_model.EditorProperties.MaximumPathText)) {
                sb.AppendFormat("Maximum=\"{0}\" ", Helpers.ConstructBinding(_model.EditorProperties.MaximumPathText, _model.BindingMode, String.Empty, _model.BindingConverter));
            } else {
                sb.Append($"Maximum=\"{_model.EditorProperties.Maximum}\" ");
            }

            if (!String.IsNullOrWhiteSpace(_model.EditorProperties.MinimumPathText)) {
                sb.AppendFormat("Minimum=\"{0}\" ", Helpers.ConstructBinding(_model.EditorProperties.MinimumPathText, _model.BindingMode, String.Empty, _model.BindingConverter));
            } else {
                sb.Append($"Minimum=\"{_model.EditorProperties.Minimum}\" ");
            }

            if (parentGridColumn != null) {
                sb.Append($"Grid.Column=\"{parentGridColumn.Value}\" ");
            }
            if (parentGridRow != null) {
                sb.Append($"Grid.Row=\"{parentGridRow.Value}\" ");
            }

            sb.Append(_model.WidthText);
            sb.Append(_model.HeightText);
            sb.Append(_model.HorizontalAlignmentText);
            sb.Append(_model.VerticalAlignmentText);
            sb.Append(_model.ControlNameText);
            sb.Append("/>");
            return sb.ToString().CompactString();
        }

    }
}
