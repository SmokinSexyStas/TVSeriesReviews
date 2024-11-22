using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TVSeriesReviews.WPF.Models.Data
{
    public static class DataWorker
    {
        public static ViewModels.HomeViewModel HomeViewModel
        {
            get => default;
            set
            {
            }
        }

        public static TVSeriesReviewsContext TVSeriesReviewsContext
        {
            get => default;
            set
            {
            }
        }

        public static TVShow GetCompleteTVShow(int id)
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                TVShow? tvShow = db.TVShows.Include(tvShow => tvShow.TVShowDirectors)
                    .ThenInclude(tvShowDirector => tvShowDirector.Director)
                .Include(tvShow => tvShow.TVShowGenres)
                    .ThenInclude(tvShowGenre => tvShowGenre.Genre)
                .Include(tvShow => tvShow.TVShowActors)
                    .ThenInclude(tvShowActor => tvShowActor.Actor)
                .Include(tvShow => tvShow.Seasons)
                    .ThenInclude(tvShowSeason => tvShowSeason.Episodes)
                .Include(tvShow => tvShow.Reviews)
                    .ThenInclude(tvShowReview => tvShowReview.User)
                .Include(tvShow => tvShow.Reviews)
                    .ThenInclude(tvShowReview => tvShowReview.ReviewLikes)
                .FirstOrDefault(tvShow => tvShow.Id == id);

                return tvShow;
            }
        }

        public static bool IsUserExists(User user)
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                User? dbUser = db.Users?.FirstOrDefault(u => u.Login == user.Login);
                if (dbUser != null)
                {
                    byte[] salt = Convert.FromBase64String(dbUser.Salt);

                    bool isPasswordValid = Security.VerifyPassword(user.Password, dbUser.Password, salt);

                    return isPasswordValid;
                }
                else
                {
                    return false;
                }
            }
        }

        //////////////////////////////////////
        public static string CreateTVShow(string title, string description = "")
        {
            string result = "Creation fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                TVShow tvShow = new TVShow();
                tvShow.Title = title;
                tvShow.Description = description;
                db.TVShows.Add(tvShow);
                db.SaveChanges();
                result = "Successfully created";
            }
            return result;
        }

        public static List<TVShow> GetAllTVShows()
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                List<TVShow> result = db.TVShows.ToList();
                return result;
            }
        }

        public static string UpdateTVShow(TVShow tvShow, string title, string description)
        {
            string result = "Update fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                TVShow? show = db.TVShows.FirstOrDefault(s => s.Id == tvShow.Id);
                if (show != null)
                {
                    show.Title = title;
                    show.Description = description;
                    db.SaveChanges();
                    result = "Successfully updated";
                }
            }
            return result;
        }

        public static string DeleteTVShow(TVShow tvShow)
        {
            string result = "Delete fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                if (tvShow != null)
                {
                    db.TVShows.Remove(tvShow);
                    db.SaveChanges();
                    result = "Successfully deleted";
                }
            }
            return result;
        }


        public static bool CreateUser(User user)
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                if (db.Users.Any(u => u.Login == user.Login))
                {
                    return false;
                }
                else
                {
                    byte[] salt;
                    user.Password = Security.HashPassword(user.Password, out salt);
                    user.Salt = Convert.ToBase64String(salt);

                    db.Users.Add(user);
                    int savedRecords = db.SaveChanges();
                    return savedRecords > 0;
                }
            }
        }

        public static List<User> GetAllUsers()
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                List<User> result = db.Users.ToList();
                return result;
            }
        }

        public static string UpdateUser(User user, string login, string password)
        {
            string result = "Update fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                User? User = db.Users.FirstOrDefault(u => u.Id == user.Id);
                if (User != null)
                {
                    User.Login = login;
                    User.Password = password;
                    db.SaveChanges();
                    result = "Successfully updated";
                }
            }
            return result;
        }

        public static bool DeleteUser(User user)
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                User? u = db.Users.FirstOrDefault(u => u.Login == user.Login);
                if (u != null)
                {
                    db.Users.Remove(u);
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public static string CreateReview(Review review)
        {
            string result = "Creation fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                result = "Successfully created";
            }
            return result;
        }

        public static List<Review> GetAllReviews()
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                List<Review> result = db.Reviews.ToList();
                return result;
            }
        }

        public static string UpdateReview(Review review, string text, int rate, int usersRate)
        {
            string result = "Update fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                Review? Review = db.Reviews.FirstOrDefault(r => r.Id == review.Id);
                if (Review != null)
                {
                    Review.Text = text;
                    Review.Rate = rate;
                    Review.Users_Rate = usersRate;
                    db.SaveChanges();
                    result = "Successfully updated";
                }
            }
            return result;
        }

        public static string DeleteReview(Review review)
        {
            string result = "Delete fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                if (review != null)
                {
                    db.Reviews.Remove(review);
                    db.SaveChanges();
                    result = "Successfully deleted";
                }
            }
            return result;
        }
    }
}
