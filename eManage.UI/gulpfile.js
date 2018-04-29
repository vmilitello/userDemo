var gulp = require('gulp');
var concat = require('gulp-concat');
var ngAnnotate = require('gulp-ng-annotate');
var uglify = require('gulp-uglify');

gulp.task('default', function() {
    return gulp.src([
                    'app/modules/**/*.js',
                    'app/eManage.app.js'])
			.pipe(concat('eManage.app.min.js', {newLine: ';'}))
            .pipe(ngAnnotate({add: true}))
            .pipe(uglify({mangle: true}))
        .pipe(gulp.dest('scripts/'));
});