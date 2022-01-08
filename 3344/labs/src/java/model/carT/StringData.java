package model.carT;

import dbUtils.FormatUtils;
import java.sql.ResultSet;


/* The purpose of this class is just to "bundle together" all the 
 * character data that the user might type in when they want to 
 * add a new Customer or edit an existing customer.  This String
 * data is "pre-validated" data, meaning they might have typed 
 * in a character string where a number was expected.
 * 
 * There are no getter or setter methods since we are not trying to
 * protect this data in any way.  We want to let the JSP page have
 * free access to put data in or take it out. */
public class StringData {

    public String carId = "";
    public String descriptor = "";
    public String urlImage = "";
    public String urlWeb = "";
    public String designDate = "";
    public String carRate = "";   

    public String errorMsg = "";

    // default constructor leaves all data members with empty string (Nothing null).
    public StringData() {
    }

    // overloaded constructor sets all data members by extracting from resultSet.
    public StringData(ResultSet results) {
        try {
            this.carId = FormatUtils.formatInteger(results.getObject("Car_id"));
            this.descriptor = FormatUtils.formatString(results.getObject("Descriptor"));
            this.urlImage= FormatUtils.formatString(results.getObject("URL_image"));
            this.urlWeb = FormatUtils.formatString(results.getObject("URL_web"));
            this.designDate = FormatUtils.formatDate(results.getObject("Design_date"));
            this.carRate = FormatUtils.formatInteger(results.getObject("Car_rate"));
        } catch (Exception e) {
            this.errorMsg = "Exception thrown in model.carT.StringData (the constructor that takes a ResultSet): " + e.getMessage();
        }
    }

    public int getCharacterCount() {
        String s = this.carId + this.descriptor + this.urlImage + this.urlWeb
                + this.designDate + this.carRate;
        return s.length();
    }

    public String toString() {
        return "Car Id:" + this.carId
                + ", DEscriptor: " + this.descriptor
                + ", Url Image: " + this.urlImage
                + ", Url Web: " + this.urlWeb
                + ", Design Date: " + this.designDate
                + ", Car Rate: " + this.carRate;
    }
}
