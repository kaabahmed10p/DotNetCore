using System.Collections.Generic;
using System.Linq;
using DomainModel.Model;
using System;

namespace TodoApi.Models
{
    public class ResultsViewModel
    {
		public long DataEventRecordId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Timestamp { get; set; }
		public SourceInfoViewModel SourceInfo { get; set; }
		public long SourceInfoId { get; set; }
	}
	public class SourceInfoViewModel
	{
		public long SourceInfoId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Timestamp { get; set; }
		public List<ResultsViewModel> DataEventRecords { get; set; }
	}

}