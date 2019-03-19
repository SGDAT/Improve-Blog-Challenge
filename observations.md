The SimpleBlog.API project relies on a placeholder data source which does not have an ideal slug option. It would be better for the slug to be stored in the original source for consistency and stability. With this solution, I decided it was neccessary to recreate the slug for each request based off the title.

The blog colours was set using the titles to generate a hash value.