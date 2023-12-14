using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Dtos
{
    public class PageDetailsDto
    {
        public PageDetailsDto(long total_records, int page_size, int pageNumber, int total_pages)
        {
            this.total_records = total_records;
            this.current_page = pageNumber;
            this.page_size = page_size;
            this.total_pages = total_pages;
        }

        public long total_records { get; }
        public int current_page { get; }
        public int page_size { get; }
        public int total_pages { get; }
    }
}
