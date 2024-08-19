using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel; // For .xlsx files
using NPOI.HSSF.UserModel; // For .xls files

/// <summary>
///  This class reads excel file type
/// </summary>
public class SearchExcelReader{
    
    /// <summary>
    ///     Reads excel files (.xls and .xslx)
    /// </summary>
    /// <param name="path">excel file path</param>
    /// <returns>Returns excel file content</returns>
    public static string? readExcel(string path){

        string? content = null;

        IWorkbook workbook;

        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            if (Path.GetExtension(path).ToLower() == ".xlsx")
            {
                workbook = new XSSFWorkbook(fs); // .xlsx
            }
            else if (Path.GetExtension(path).ToLower() == ".xls")
            {
                workbook = new HSSFWorkbook(fs); // .xls
            }
            else
            {
                throw new Exception("Invalid file type");
            }
        }

        ISheet sheet = workbook.GetSheetAt(0); // Get first sheet
        for (int row = 0; row <= sheet.LastRowNum; row++)
        {
            IRow rowData = sheet.GetRow(row);
            for (int col = 0; col < rowData.LastCellNum; col++)
            {
                content = content! + rowData.GetCell(col) + "\t";
            }
            content = content! + "\n";
        }

        return content;
    }
}