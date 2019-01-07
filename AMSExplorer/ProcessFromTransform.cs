﻿//----------------------------------------------------------------------------------------------
//    Copyright 2019 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.IO;
using Microsoft.Azure.Management.Media.Models;

namespace AMSExplorer
{
    public partial class ProcessFromTransform : Form
    {
        private int sortColumn = -1;
        private AMSClientV3 _client;
        private int _numberselectedassets = 0;

        public Transform SelectedTransform
        {
            get
            {
                return listViewTransforms.GetSelectedTransform;

            }
        }

        public JobOptionsVar JobOptions
        {
            get
            {
                return buttonJobOptions.GetSettings();
            }
            set
            {
                buttonJobOptions.SetSettings(value);
            }
        }

        public string ProcessingJobName
        {
            get
            {
                return textBoxJobName.Text;
            }
            set
            {
                textBoxJobName.Text = value;
            }
        }


        public string ProcessingPromptText
        {
            set
            {
                label.Text = value;
            }
        }



        public ProcessFromTransform(AMSClientV3 client, int numberselectedassets)
        {
            InitializeComponent();
            this.Icon = Bitmaps.Azure_Explorer_ico;
            _client = client;
            _numberselectedassets = numberselectedassets;
            labelWarning.Text = string.Empty;
            //buttonJobOptions.Initialize(_context);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = listViewTransforms.SelectedItems.Count > 0;
            buttonDeleteTemplate.Enabled = listViewTransforms.SelectedItems.Count > 0;

          
        }

        private void ProcessFromJobTemplate_Load(object sender, EventArgs e)
        {
            listViewTransforms.LoadTransforms(_client);
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void buttonDeleteTemplate_Click(object sender, EventArgs e)
        {

            listViewTransforms.DeleteSelectedTemplate();
        }
    }
}
