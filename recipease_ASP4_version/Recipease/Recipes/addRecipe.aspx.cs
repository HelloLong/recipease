﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;      // For the database connections and objects.
using Microsoft.SqlServer.Server;
using System.Configuration;
using System.Data;

public partial class Recipes_addRecipe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.DefaultFocus = RecipeNameTXT.ClientID; // default textbox focus on page load
        this.Form.DefaultButton = this.AddRecipeBTN.UniqueID; // default button when enter is pressed
    }

    protected void AddRecipeBTN_Click(object sender, EventArgs e) // adds recipe data to various tables in db
    {
        string FileName = Path.GetFileName(FileUpload1.FileName); // stores relative filename path of uploaded image

        if (FileName != "")
        {
            FileName = "~/Images/Recipes/" + FileName;
            FileUpload1.SaveAs(Server.MapPath(FileName));
        }
        else
        {
            FileName = "";
        }

        try
        {
            // insert form data as a new row in the RECIPE table
            if (RecipeNameTXT.Text != "") // default text check
            {
                RecipeaseSDS.InsertParameters["rec_name"].DefaultValue = RecipeNameTXT.Text;
            }
            if (RecipeDescriptionTXT.Text != "")
            {
                RecipeaseSDS.InsertParameters["rec_desc"].DefaultValue = RecipeDescriptionTXT.Text;
            }
            if (PrepTimeTXT.Text != "")
            {
                RecipeaseSDS.InsertParameters["rec_prep_time"].DefaultValue = PrepTimeTXT.Text;
            }
            if (CookTimeTXT.Text != "")
            {
                RecipeaseSDS.InsertParameters["rec_cook_time"].DefaultValue = CookTimeTXT.Text;
            }
            if (CookTempTXT.Text != "")
            {
                RecipeaseSDS.InsertParameters["rec_cook_temp"].DefaultValue = CookTempTXT.Text;
            }
            if (TotalTimeTXT.Text != "")
            {
                RecipeaseSDS.InsertParameters["rec_ready_time"].DefaultValue = TotalTimeTXT.Text;
            }
            if (ServingSizeTXT.Text != "")
            {
                RecipeaseSDS.InsertParameters["rec_serving_size"].DefaultValue = ServingSizeTXT.Text;
            }
            RecipeaseSDS.InsertParameters["rec_date"].DefaultValue = DateTime.Now.ToString();
            RecipeaseSDS.InsertParameters["rec_image_path"].DefaultValue = FileName;
            RecipeaseSDS.InsertParameters["rec_owner"].DefaultValue = User.Identity.Name.ToString();
            if (RatingTXT.Text != "")
            {
                RecipeaseSDS.InsertParameters["rec_rating"].DefaultValue = RatingTXT.Text;
            }
            if (DirectionsTXT.Text != "")
            {
                RecipeaseSDS.InsertParameters["rec_directions"].DefaultValue = DirectionsTXT.Text;
            }

            // perform actual insert in RECIPE table
            RecipeaseSDS.Insert();

            // now that recipe has been created, insert form data as new row(s) in the INGREDIENT table 
            /*** INSERT QUERIES START ***/
            if (Ingredient01TXT.Text != ""
                    || Ingredient02TXT.Text != ""
                    || Ingredient03TXT.Text != ""
                    || Ingredient04TXT.Text != ""
                    || Ingredient05TXT.Text != ""
                    || Ingredient06TXT.Text != ""
                    || Ingredient07TXT.Text != ""
                    || Ingredient08TXT.Text != ""
                    || Ingredient09TXT.Text != ""
                    || Ingredient10TXT.Text != ""
                    || Ingredient11TXT.Text != ""
                    || Ingredient12TXT.Text != ""
                    || Ingredient13TXT.Text != ""
                    || Ingredient14TXT.Text != ""
                    || Ingredient15TXT.Text != ""
                    || Ingredient16TXT.Text != ""
                    || Ingredient17TXT.Text != ""
                    || Ingredient18TXT.Text != ""
                    || Ingredient19TXT.Text != ""
                    || Ingredient20TXT.Text != ""
                    )
            {
                // 1.  open the Connection object for the context
                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["INFO3420_12ConnectionString"].ConnectionString);
                myConnection.Open();

                // 2.  create new sql command object to write to the database
                SqlCommand insert01 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert02 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert03 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert04 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert05 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert06 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert07 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert08 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert09 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert10 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert11 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert12 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert13 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert14 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert15 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert16 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert17 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert18 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert19 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);
                SqlCommand insert20 = new SqlCommand("insert_into_RECIPE_INGREDIENT", myConnection);

                //3. set up sprocs with proper values and execute!
                if (Ingredient01TXT.Text != "")
                {
                    insert01.CommandType = CommandType.StoredProcedure;
                    insert01.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert01.Parameters.AddWithValue("@ing_name", Ingredient01TXT.Text);
                    insert01.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity01TXT.Text));
                    insert01.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert01.Parameters.AddWithValue("@unit_name", Amount01DDL.SelectedValue);
                    insert01.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient02TXT.Text != "")
                {
                    insert02.CommandType = CommandType.StoredProcedure;
                    insert02.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert02.Parameters.AddWithValue("@ing_name", Ingredient02TXT.Text);
                    insert02.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity02TXT.Text));
                    insert02.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert02.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount02DDL.SelectedValue));
                    insert02.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient03TXT.Text != "")
                {
                    insert03.CommandType = CommandType.StoredProcedure;
                    insert03.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert03.Parameters.AddWithValue("@ing_name", Ingredient03TXT.Text);
                    insert03.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity03TXT.Text));
                    insert03.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert03.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount03DDL.SelectedValue));
                    insert03.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient04TXT.Text != "")
                {
                    insert04.CommandType = CommandType.StoredProcedure;
                    insert04.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert04.Parameters.AddWithValue("@ing_name", Ingredient04TXT.Text);
                    insert04.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity04TXT.Text));
                    insert04.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert04.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount04DDL.SelectedValue));
                    insert04.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient05TXT.Text != "")
                {
                    insert05.CommandType = CommandType.StoredProcedure;
                    insert05.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert05.Parameters.AddWithValue("@ing_name", Ingredient05TXT.Text);
                    insert05.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity05TXT.Text));
                    insert05.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert05.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount05DDL.SelectedValue));
                    insert05.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient06TXT.Text != "")
                {
                    insert06.CommandType = CommandType.StoredProcedure;
                    insert06.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert06.Parameters.AddWithValue("@ing_name", Ingredient06TXT.Text);
                    insert06.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity06TXT.Text));
                    insert06.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert06.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount06DDL.SelectedValue));
                    insert06.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient07TXT.Text != "")
                {
                    insert07.CommandType = CommandType.StoredProcedure;
                    insert07.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert07.Parameters.AddWithValue("@ing_name", Ingredient07TXT.Text);
                    insert07.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity07TXT.Text));
                    insert07.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert07.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount07DDL.SelectedValue));
                    insert07.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient08TXT.Text != "")
                {
                    insert08.CommandType = CommandType.StoredProcedure;
                    insert08.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert08.Parameters.AddWithValue("@ing_name", Ingredient08TXT.Text);
                    insert08.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity08TXT.Text));
                    insert08.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert08.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount08DDL.SelectedValue));
                    insert08.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient09TXT.Text != "")
                {
                    insert09.CommandType = CommandType.StoredProcedure;
                    insert09.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert09.Parameters.AddWithValue("@ing_name", Ingredient09TXT.Text);
                    insert09.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity09TXT.Text));
                    insert09.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert09.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount09DDL.SelectedValue));
                    insert09.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient10TXT.Text != "")
                {
                    insert10.CommandType = CommandType.StoredProcedure;
                    insert10.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert10.Parameters.AddWithValue("@ing_name", Ingredient10TXT.Text);
                    insert10.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity10TXT.Text));
                    insert10.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert10.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount10DDL.SelectedValue));
                    insert10.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient11TXT.Text != "")
                {
                    insert11.CommandType = CommandType.StoredProcedure;
                    insert11.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert11.Parameters.AddWithValue("@ing_name", Ingredient11TXT.Text);
                    insert11.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity11TXT.Text));
                    insert11.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert11.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount11DDL.SelectedValue));
                    insert11.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient12TXT.Text != "")
                {
                    insert12.CommandType = CommandType.StoredProcedure;
                    insert12.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert12.Parameters.AddWithValue("@ing_name", Ingredient12TXT.Text);
                    insert12.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity12TXT.Text));
                    insert12.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert12.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount12DDL.SelectedValue));
                    insert12.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient13TXT.Text != "")
                {
                    insert13.CommandType = CommandType.StoredProcedure;
                    insert13.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert13.Parameters.AddWithValue("@ing_name", Ingredient13TXT.Text);
                    insert13.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity13TXT.Text));
                    insert13.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert13.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount13DDL.SelectedValue));
                    insert13.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient14TXT.Text != "")
                {
                    insert14.CommandType = CommandType.StoredProcedure;
                    insert14.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert14.Parameters.AddWithValue("@ing_name", Ingredient14TXT.Text);
                    insert14.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity14TXT.Text));
                    insert14.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert14.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount14DDL.SelectedValue));
                    insert14.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient15TXT.Text != "")
                {
                    insert15.CommandType = CommandType.StoredProcedure;
                    insert15.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert15.Parameters.AddWithValue("@ing_name", Ingredient15TXT.Text);
                    insert15.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity15TXT.Text));
                    insert15.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert15.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount15DDL.SelectedValue));
                    insert15.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient16TXT.Text != "")
                {
                    insert16.CommandType = CommandType.StoredProcedure;
                    insert16.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert16.Parameters.AddWithValue("@ing_name", Ingredient16TXT.Text);
                    insert16.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity16TXT.Text));
                    insert16.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert16.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount16DDL.SelectedValue));
                    insert16.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient17TXT.Text != "")
                {
                    insert17.CommandType = CommandType.StoredProcedure;
                    insert17.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert17.Parameters.AddWithValue("@ing_name", Ingredient17TXT.Text);
                    insert17.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity17TXT.Text));
                    insert17.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert17.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount17DDL.SelectedValue));
                    insert17.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient18TXT.Text != "")
                {
                    insert18.CommandType = CommandType.StoredProcedure;
                    insert18.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert18.Parameters.AddWithValue("@ing_name", Ingredient18TXT.Text);
                    insert18.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity18TXT.Text));
                    insert18.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert18.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount18DDL.SelectedValue));
                    insert18.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient19TXT.Text != "")
                {
                    insert19.CommandType = CommandType.StoredProcedure;
                    insert19.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert19.Parameters.AddWithValue("@ing_name", Ingredient19TXT.Text);
                    insert19.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity19TXT.Text));
                    insert19.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert19.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount19DDL.SelectedValue));
                    insert19.ExecuteNonQuery(); //execute the sproc
                }

                if (Ingredient20TXT.Text != "")
                {
                    insert20.CommandType = CommandType.StoredProcedure;
                    insert20.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insert20.Parameters.AddWithValue("@ing_name", Ingredient20TXT.Text);
                    insert20.Parameters.AddWithValue("@rec_ing_quantity", Convert.ToDecimal(Quantity20TXT.Text));
                    insert20.Parameters.Add("@unit_id", SqlDbType.Int).Value = 0;
                    insert20.Parameters.AddWithValue("@unit_name", Convert.ToString(Amount20DDL.SelectedValue));
                    insert20.ExecuteNonQuery(); //execute the sproc
                }

                // 4.  close the Connection object for the context
                myConnection.Close();
            }

            // loop through items in the TAG list box and insert user-selected values into the TAG table
            foreach (ListItem item in TagsLBX.Items)
            {
                SqlConnection myConnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["INFO3420_12ConnectionString"].ConnectionString);
                myConnection2.Open();

                if (item.Selected)
                {
                    SqlCommand insertTAG = new SqlCommand("insert_into_RECIPE_TAG", myConnection2);
                    insertTAG.CommandType = CommandType.StoredProcedure;
                    insertTAG.Parameters.Add("@rec_id", SqlDbType.Int).Value = 0;
                    insertTAG.Parameters.Add("@tag_id", SqlDbType.Int).Value = 0;
                    insertTAG.Parameters.AddWithValue("@tag_name", item.Text);
                    insertTAG.ExecuteNonQuery(); //execute the sproc
                }

                myConnection2.Close();
                //REFERENCE: to capture output variable, do: 
                // insert01.Parameters["@OUTPUT_VARIABLE_NAME"].Direction = ParameterDirection.Output;
                // insert01.ExecuteNonQuery();
                // int ID_var = (int) maxRecID.Parameters["@OUTPUT_VARIABLE_NAME"].Value;
                //REFERENCE: then in the sproc, declare as an output variable, and for identity columns, 
                //REFERENCE: at the end SET @OUTPUT_VARIABLE_NAME = SCOPE_IDENTITY()
            }
            /*** INSERT QUERIES END ***/

            // reset stuff to default values if insert succeeds
            RecipeNameTXT.Text = "";
            RecipeDescriptionTXT.Text = "";
            PrepTimeTXT.Text = "";
            CookTimeTXT.Text = "";
            CookTempTXT.Text = "";
            TotalTimeTXT.Text = "";
            ServingSizeTXT.Text = "";
            RatingTXT.Text = "";
            DirectionsTXT.Text = "";
            Ingredient01TXT.Text = "";
            Ingredient01TXT.Text = "";
            Ingredient02TXT.Text = "";
            Ingredient03TXT.Text = "";
            Ingredient04TXT.Text = "";
            Ingredient05TXT.Text = "";
            Ingredient06TXT.Text = "";
            Ingredient07TXT.Text = "";
            Ingredient08TXT.Text = "";
            Ingredient09TXT.Text = "";
            Ingredient10TXT.Text = "";
            Ingredient11TXT.Text = "";
            Ingredient12TXT.Text = "";
            Ingredient13TXT.Text = "";
            Ingredient14TXT.Text = "";
            Ingredient15TXT.Text = "";
            Ingredient16TXT.Text = "";
            Ingredient17TXT.Text = "";
            Ingredient18TXT.Text = "";
            Ingredient19TXT.Text = "";
            Ingredient20TXT.Text = "";
            Quantity01TXT.Text = "";
            Quantity02TXT.Text = "";
            Quantity03TXT.Text = "";
            Quantity04TXT.Text = "";
            Quantity05TXT.Text = "";
            Quantity06TXT.Text = "";
            Quantity07TXT.Text = "";
            Quantity08TXT.Text = "";
            Quantity09TXT.Text = "";
            Quantity10TXT.Text = "";
            Quantity11TXT.Text = "";
            Quantity12TXT.Text = "";
            Quantity13TXT.Text = "";
            Quantity14TXT.Text = "";
            Quantity15TXT.Text = "";
            Quantity16TXT.Text = "";
            Quantity17TXT.Text = "";
            Quantity18TXT.Text = "";
            Quantity19TXT.Text = "";
            Quantity20TXT.Text = "";
            Amount01DDL.SelectedIndex = 0; // drop downs for unit amounts will display the default text
            Amount02DDL.SelectedIndex = 0;
            Amount03DDL.SelectedIndex = 0;
            Amount04DDL.SelectedIndex = 0;
            Amount05DDL.SelectedIndex = 0;
            Amount06DDL.SelectedIndex = 0;
            if (Panel1.Visible) // only reset if other ingredient fields are visible
            {
                Amount07DDL.SelectedIndex = 0;
                Amount08DDL.SelectedIndex = 0;
                Amount09DDL.SelectedIndex = 0;
                Amount10DDL.SelectedIndex = 0;
                Amount11DDL.SelectedIndex = 0;
                Amount12DDL.SelectedIndex = 0;
                Amount13DDL.SelectedIndex = 0;
                Amount14DDL.SelectedIndex = 0;
                Amount15DDL.SelectedIndex = 0;
                Amount16DDL.SelectedIndex = 0;
                Amount17DDL.SelectedIndex = 0;
                Amount18DDL.SelectedIndex = 0;
                Amount19DDL.SelectedIndex = 0;
                Amount20DDL.SelectedIndex = 0;
            }
            TagsLBX.SelectedIndex = -1; // resets all listbox selections

            // go back to main recipe page if insert succeeds
            Response.Redirect("index.aspx");
        }
        catch (Exception ex)
        {
            ErrorsLBL.Text = "An exception occurrred adding the recipe. " + ex.Message;
        }
    }

    protected void ResetRecipeBTN_Click(object sender, EventArgs e)
    {
            // reset stuff to default values
            RecipeNameTXT.Text = "";
            RecipeDescriptionTXT.Text = "";
            PrepTimeTXT.Text = "";
            CookTimeTXT.Text = "";
            CookTempTXT.Text = "";
            TotalTimeTXT.Text = "";
            ServingSizeTXT.Text = "";
            RatingTXT.Text = "";
            DirectionsTXT.Text = "";
            Ingredient01TXT.Text = "";
            Ingredient01TXT.Text = "";
            Ingredient02TXT.Text = "";
            Ingredient03TXT.Text = "";
            Ingredient04TXT.Text = "";
            Ingredient05TXT.Text = "";
            Ingredient06TXT.Text = "";
            Ingredient07TXT.Text = "";
            Ingredient08TXT.Text = "";
            Ingredient09TXT.Text = "";
            Ingredient10TXT.Text = "";
            Ingredient11TXT.Text = "";
            Ingredient12TXT.Text = "";
            Ingredient13TXT.Text = "";
            Ingredient14TXT.Text = "";
            Ingredient15TXT.Text = "";
            Ingredient16TXT.Text = "";
            Ingredient17TXT.Text = "";
            Ingredient18TXT.Text = "";
            Ingredient19TXT.Text = "";
            Ingredient20TXT.Text = "";
            Quantity01TXT.Text = "";
            Quantity02TXT.Text = "";
            Quantity03TXT.Text = "";
            Quantity04TXT.Text = "";
            Quantity05TXT.Text = "";
            Quantity06TXT.Text = "";
            Quantity07TXT.Text = "";
            Quantity08TXT.Text = "";
            Quantity09TXT.Text = "";
            Quantity10TXT.Text = "";
            Quantity11TXT.Text = "";
            Quantity12TXT.Text = "";
            Quantity13TXT.Text = "";
            Quantity14TXT.Text = "";
            Quantity15TXT.Text = "";
            Quantity16TXT.Text = "";
            Quantity17TXT.Text = "";
            Quantity18TXT.Text = "";
            Quantity19TXT.Text = "";
            Quantity20TXT.Text = "";
            Amount01DDL.SelectedIndex = 0; // drop downs for unit amounts will display the default text
            Amount02DDL.SelectedIndex = 0;
            Amount03DDL.SelectedIndex = 0;
            Amount04DDL.SelectedIndex = 0;
            Amount05DDL.SelectedIndex = 0;
            Amount06DDL.SelectedIndex = 0;
            Amount07DDL.SelectedIndex = 0;
            Amount08DDL.SelectedIndex = 0;
            Amount09DDL.SelectedIndex = 0;
            Amount10DDL.SelectedIndex = 0;
            Amount11DDL.SelectedIndex = 0;
            Amount12DDL.SelectedIndex = 0;
            Amount13DDL.SelectedIndex = 0;
            Amount14DDL.SelectedIndex = 0;
            Amount15DDL.SelectedIndex = 0;
            Amount16DDL.SelectedIndex = 0;
            Amount17DDL.SelectedIndex = 0;
            Amount18DDL.SelectedIndex = 0;
            Amount19DDL.SelectedIndex = 0;
            Amount20DDL.SelectedIndex = 0;
            TagsLBX.SelectedIndex = -1;
    }
    protected void AddMoreIngredients01CB_CheckedChanged(object sender, EventArgs e)
    {
        Panel1.Visible = AddMoreIngredients01CB.Checked; // display more ingredient fields if checked
    }
}