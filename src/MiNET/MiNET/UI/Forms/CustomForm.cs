﻿using System;
using Newtonsoft.Json.Linq;
using MiNET.UI.Elements;
using System.Collections.Generic;

namespace MiNET.UI.Forms
{
	public class CustomForm : IForm
	{
		public List<IElement> Elements { get; set; }
		public string Title { get; set; }

		public CustomForm(string title)
		{
			Title = title;
			Elements = new List<IElement>();
		}

		public void AddElement(IElement element)
		{
			if(element is Button)
			{
				throw new UiException("Button can't be added to CustomForm!");
			}
			Elements.Add(element);
		}

		public JArray GetElements()
		{
			var j = new JArray();
			foreach(var element in Elements)
				j.Add(element.GetData());
			return j;
		}

		public string GetData()
		{
			var j = new JObject
			{
				{ "type", "custom_form" },
				{ "title", Title },
				{ "content", GetElements() }
			};
			return j.ToString(Newtonsoft.Json.Formatting.None);
		}
		public void Process(Player player, JArray response)
		{
			for(var i = 0; i < response.Count; i++)
			{
				Console.WriteLine(response[i]);
				Elements[i].Process(player, response[i]);
			}
		}
	}
}
